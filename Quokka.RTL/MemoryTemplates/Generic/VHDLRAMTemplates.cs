using Quokka.RTL.Tools;
using Quokka.RTL.VHDL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL.MemoryTemplates.Generic
{
    public class VHDLRAMTemplates : GenericRAMTemplates
    {
        protected readonly IRTLSignalInfoProvider _rtlSignalInfoProvider;
        protected readonly vhdArchitectureDeclarations _declarations;
        protected readonly vhdArchitectureImplementation _implementation;

        public VHDLRAMTemplates(
            IRTLSignalInfoProvider rtlSignalInfoProvider,
            vhdArchitectureDeclarations declarations, 
            vhdArchitectureImplementation implementation
        )
            : base()
        {
            _rtlSignalInfoProvider = rtlSignalInfoProvider;
            _declarations = declarations;
            _implementation = implementation;
        }

        string RegName(RAMTemplateData<vhdIdentifier> template, vhdIdentifier data)
        {
            var indexes = Indexes(data);
            var regParts = new List<string>();
            regParts.Add(indexes[0]);

            regParts.Add($"reg{template.RegSuffix}");

            return string.Join("_", regParts);
        }

        List<vhdIdentifier> Identifiers(vhdIdentifier data)
        {
            var result = new List<vhdIdentifier>() { data.Name };

            result.AddRange(IndexIdentifiers(data));

            return result;
        }

        List<vhdIdentifier> IndexIdentifiers(vhdIdentifier data)
        {
            var result = new List<vhdIdentifier>();

            foreach (var idx in data.Indexes.SelectMany(i => i.Indexes))
            {
                switch (idx)
                {
                    case vhdIdentifierExpression e: 
                        if (!int.TryParse(e.Source.Name, out var _))
                            result.Add(e.Source); 
                        break;
                }
            }

            return result;
        }

        List<string> Indexes(vhdIdentifier data)
        {
            return data.Indexes.SelectMany(r =>
            {
                return r.Indexes.Select(i =>
                {
                    switch (i)
                    {
                        case vhdIdentifierExpression e: return e.Source.Name;
                        default: throw new Exception($"Unsupported index expression: {i.GetType().Name}");
                    }
                });
            }).ToList();
        }

        List<string> Indexes(RAMTemplateData<vhdIdentifier> data)
        {
            var result = data.Read.SelectMany(r => Indexes(r.Source))
                .Concat(data.Write.SelectMany(w => Indexes(w.Target)))
                .Distinct()
                .ToList();

            return result;
        }

        List<vhdRange> MemoryIndexing(List<vhdRange> source)
        {
            return source.Select(range =>
            {
                if (range.Indexes.Count == 1 && range.Indexes[0] is vhdIdentifierExpression id && !int.TryParse(id.Source.Name, out var _))
                {
                    return new vhdProcedureCallExpression("TO_INTEGER", id);
                }
                else
                {
                    return range;
                }
            }).ToList();
        }

        public void SDP_RF(RAMTemplateData<vhdIdentifier> data)
        {
            var clock = data.Clock;

            var addrs = Indexes(data);

            if (addrs.Count == 1)
                _implementation.Block.WithComment("inferred single port RAM with read-first behaviour");
            else
                _implementation.Block.WithComment("inferred simple dual port RAM with read-first behaviour");

            var syncBlock = new vhdSyncBlock(vhdEdgeType.Rising, clock);
            var process = new vhdProcess()
            {
                SensitivityList = { clock },
                Block = { syncBlock }
            };

            foreach (var write in data.Write)
            {
                if (write.WriteEnable != null)
                    process.SensitivityList.Add(write.WriteEnable);

                process.SensitivityList.AddRange(IndexIdentifiers(write.Target));
                process.SensitivityList.AddRange(Identifiers(write.Sources.Single()));

                if (write.WriteEnable != null)
                {
                    syncBlock.Block.WithIf(
                        new vhdIf()
                        {
                            new vhdConditionalStatement(new vhdCompareExpression(write.WriteEnable, vhdCompareType.Equal, "'1'"))
                            {
                                new vhdAssignExpression(
                                    new vhdIdentifierExpression(write.Target.Name, MemoryIndexing(write.Target.Indexes)),
                                    vhdAssignType.Signal,
                                    write.Sources.Single()
                                )
                            }
                        }
                    );
                }
                else
                {
                    syncBlock.Block.WithAssignExpression(
                        new vhdIdentifierExpression(write.Target.Name, MemoryIndexing(write.Target.Indexes)),
                        vhdAssignType.Signal,
                        write.Sources.Single()
                    );
                }
            }

            foreach (var read in data.Read)
            {
                process.SensitivityList.AddRange(Identifiers(read.Source));

                syncBlock.Block.WithAssignExpression(
                    read.Targets.Single(),
                    vhdAssignType.Signal,
                    new vhdIdentifierExpression(read.Source.Name, MemoryIndexing(read.Source.Indexes))
                );
            }

            _implementation.Block.WithProcess(process);
        }

        public void SDP_WF(RAMTemplateData<vhdIdentifier> data)
        {
            var clock = data.Clock;
            var ram = data.RAM;
            var ramDepth = data.RAMDepth;

            var addrs = Indexes(data);

            if (addrs.Count == 1)
                _implementation.Block.WithComment("inferred single port RAM with write-first behaviour");
            else
                _implementation.Block.WithComment("inferred simple dual port RAM with write-first behaviour");

            var ramAddressBits = (int)RTLCalculators.CalcBitsForValue((ulong)(ramDepth - 1));
            foreach (var read in data.Read)
            {
                var readAddrReg = RegName(data, read.Source);
                _declarations.WithDefaultSignal(vhdNetType.Signal, readAddrReg, vhdDataType.Unsigned, ramAddressBits);
            }

            var syncBlock = new vhdSyncBlock(vhdEdgeType.Rising, clock);

            var process = new vhdProcess()
            {
                SensitivityList = { clock },
                Block = { syncBlock }
            };

            foreach (var write in data.Write)
            {
                if (write.WriteEnable != null)
                    process.SensitivityList.Add(write.WriteEnable);

                process.SensitivityList.AddRange(IndexIdentifiers(write.Target));
                process.SensitivityList.AddRange(Identifiers(write.Sources.Single()));

                if (write.WriteEnable != null)
                {
                    syncBlock.Block.WithIf(
                        new vhdIf()
                        {
                            new vhdConditionalStatement(new vhdCompareExpression(write.WriteEnable, vhdCompareType.Equal, "'1'"))
                            {
                                new vhdAssignExpression(
                                    new vhdIdentifierExpression(write.Target.Name, MemoryIndexing(write.Target.Indexes)),
                                    vhdAssignType.Signal,
                                    write.Sources.Single()
                                )
                            }
                        }
                    );
                }
                else
                {
                    syncBlock.Block.WithAssignExpression(
                        new vhdIdentifierExpression(write.Target.Name, MemoryIndexing(write.Target.Indexes)),
                        vhdAssignType.Signal,
                        write.Sources.Single()
                    );
                }
            }

            foreach (var read in data.Read)
            {
                var readAddrReg = RegName(data, read.Source);

                process.SensitivityList.Add(readAddrReg);
                process.SensitivityList.AddRange(Identifiers(read.Source));

                var index = read.Source.Indexes.Single().Indexes.Single();
                switch (index)
                {
                    case vhdIdentifierExpression ie:
                        var rangedIndex = ie.Clone();
                        rangedIndex.Source.Indexes.Add(new vhdRange($"{ramAddressBits - 1}", "0"));
                        syncBlock.Block.WithAssignExpression(
                            readAddrReg,
                            vhdAssignType.Signal,
                            rangedIndex
                        );
                        break;
                    default:
                        throw new Exception($"Expecting identifier expression: {vhdVHDLWriter.WriteObject(index)}");
                }

                process.Block.WithAssignExpression(
                    read.Targets.Single(),
                    vhdAssignType.Signal,
                    new vhdIdentifierExpression(read.Source.Name, new vhdProcedureCallExpression("TO_INTEGER", readAddrReg))
                );
            }

            _implementation.Block.WithProcess(process);
        }

        public void TDP_PORT(RAMTemplateData<vhdIdentifier> data, string comments)
        {
            var clock = data.Clock;

            _implementation.Block.WithComment(comments);

            var syncBlock = new vhdSyncBlock(vhdEdgeType.Rising, clock);

            var process = new vhdProcess()
            {
                SensitivityList = { clock },
                Block = { syncBlock }
            };

            foreach (var write in data.Write)
            {
                if (write.WriteEnable != null)
                    process.SensitivityList.Add(write.WriteEnable);

                process.SensitivityList.AddRange(IndexIdentifiers(write.Target));
                process.SensitivityList.AddRange(IndexIdentifiers(write.Sources.Single()));

                if (write.WriteEnable != null)
                {
                    syncBlock.Block.WithIf(
                        new vhdIf()
                        {
                            new vhdConditionalStatement(new vhdCompareExpression(write.WriteEnable, vhdCompareType.Equal, "'1'"))
                            {
                                new vhdAssignExpression(
                                    new vhdIdentifierExpression(write.Target.Name, MemoryIndexing(write.Target.Indexes)),
                                    vhdAssignType.Variable,
                                    write.Sources.Single()
                                )
                            }
                        }
                    );
                }
                else
                {
                    syncBlock.Block.WithAssignExpression(
                        new vhdIdentifierExpression(write.Target.Name, MemoryIndexing(write.Target.Indexes)),
                        vhdAssignType.Variable,
                        write.Sources.Single()
                    );
                }
            }

            foreach (var read in data.Read)
            {
                process.SensitivityList.AddRange(IndexIdentifiers(read.Targets.Single()));
                process.SensitivityList.AddRange(IndexIdentifiers(read.Source));

                syncBlock.Block.WithAssignExpression(
                    read.Targets.Single(),
                    vhdAssignType.Signal,
                    new vhdIdentifierExpression(read.Source.Name, MemoryIndexing(read.Source.Indexes))
                );
            }

            _implementation.Block.WithProcess(process);
        }

        public void TDP(RAMTemplateData<vhdIdentifier> portA, RAMTemplateData<vhdIdentifier> portB)
        {
            TDP_PORT(portA, "Port A");
            TDP_PORT(portB, "Port B");
        }
    }
}
