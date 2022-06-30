using Quokka.RTL.Tools;
using Quokka.RTL.Verilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL.MemoryTemplates.Generic
{
    public class VerilogRAMTemplates : GenericRAMTemplates
    {
        protected readonly vlgModuleImplementation _implementation;

        public VerilogRAMTemplates(vlgModuleImplementation implementation)
            : base()
        {
            _implementation = implementation;
        }

        string RegName(RAMTemplateData<vlgIdentifier> template, vlgIdentifier data)
        {
            var indexes = Indexes(data);
            var regParts = new List<string>();
            regParts.Add(indexes[0]);

            regParts.Add($"reg{template.RegSuffix}");

            return string.Join("_", regParts);
        }

        List<string> Indexes(vlgIdentifier data)
        {
            return data.Indexes.SelectMany(r =>
            {
                return r.Indexes.Select(i =>
                {
                    switch (i)
                    {
                        case vlgIdentifierExpression e: return e.Source.Name;
                        default: throw new Exception($"Unsupported index expression: {i.GetType().Name}");
                    }
                });
            }).ToList();
        }

        List<string> Indexes(RAMTemplateData<vlgIdentifier> data)
        {
            var result = data.Read.SelectMany(r => Indexes(r.Source))
                .Concat(data.Write.SelectMany(w => Indexes(w.Target)))
                .Distinct()
                .ToList();

            return result;
        }

        public void SDP_RF(RAMTemplateData<vlgIdentifier> data)
        {
            var clock = data.Clock;
            var ram = data.RAM;

            var addrs = Indexes(data);

            if (addrs.Count == 1)
                _implementation.Block.WithComment("inferred single port RAM with read-first behaviour");
            else
                _implementation.Block.WithComment("inferred simple dual port RAM with read-first behaviour");

            var block = new vlgSyncBlock(vlgEdgeType.Pos, clock);

            foreach (var write in data.Write)
            {
                var writeEnable = write.WriteEnable;

                var assign = new vlgAssign(
                    write.Target,
                    vlgAssignType.NonBlocking,
                    write.Source
                );

                if (writeEnable == null)
                {
                    block.Add(assign);
                }
                else
                {
                    block.Add(
                        new vlgIf()
                        {
                            new vlgConditionalStatement(new vlgIdentifierExpression(writeEnable))
                            {
                                assign
                            }
                        }
                    );
                }
            }

            foreach (var read in data.Read)
            {
                block.Add(
                    new vlgAssign(
                        read.Target,
                        vlgAssignType.NonBlocking,
                        read.Source
                    )
                );
            }

            _implementation.Block.WithSyncBlock(block);
        }

        public void SDP_WF(RAMTemplateData<vlgIdentifier> data)
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
                var addrReg = RegName(data, read.Source);
                _implementation.Block.WithLogicSignal(vlgNetType.Reg, vlgSignType.Unsigned, addrReg, ramAddressBits, null);
            }


            var block = new vlgSyncBlock(vlgEdgeType.Pos, clock);

            foreach (var write in data.Write)
            {
                var writeEnable = write.WriteEnable;

                var assign = new vlgAssign(
                    write.Target,
                    vlgAssignType.NonBlocking,
                    write.Source
                );

                if (writeEnable == null)
                {
                    block.Add(assign);
                }
                else
                {
                    block.Add(
                        new vlgIf()
                        {
                            new vlgConditionalStatement(new vlgIdentifierExpression(writeEnable))
                            {
                                assign
                            }
                        }
                    );
                }
            }

            foreach (var read in data.Read)
            {
                var addrReg = RegName(data, read.Source);
                var index = read.Source.Indexes[0].Indexes[0];
                switch (index)
                {
                    case vlgIdentifierExpression ie:
                        var rangedIndex = ie.Clone();
                        rangedIndex.Source.Indexes.Add(new vlgRange($"{ramAddressBits - 1}", "0"));

                        block.Add(
                            new vlgAssign(
                                addrReg,
                                vlgAssignType.NonBlocking,
                                rangedIndex
                            )
                        );
                        break;
                    default:
                        throw new Exception($"Expecting identifier expression: {vlgVerilogWriter.WriteObject(index)}");
                }
            }

            _implementation.Block.WithSyncBlock(block);

            foreach (var read in data.Read)
            {
                var addrReg = RegName(data, read.Source);

                _implementation.Block.WithAssign(
                    new vlgAssign(
                        read.Target,
                        vlgAssignType.Assign,
                        new vlgIdentifierExpression(read.Source.Name, new vlgIdentifierExpression(addrReg))
                    )
                );
            }
        }

        public void TDP_PORT(
                RAMTemplateData<vlgIdentifier> data,
                string comments
            )
        {
            var clock = data.Clock;
            var write = data.Write.Single();
            var read = data.Read.Single();

            _implementation.Block.WithComment(comments);

            var block = new vlgSyncBlock(vlgEdgeType.Pos, clock)
            {
                Block =
                {
                    new vlgIf()
                    {
                        new vlgConditionalStatement(new vlgIdentifierExpression(write.WriteEnable))
                        {
                            new vlgAssign(
                                write.Target,
                                vlgAssignType.NonBlocking,
                                write.Source
                            ),
                            new vlgAssign(
                                read.Target,
                                vlgAssignType.NonBlocking,
                                new vlgIdentifierExpression(write.Source)
                            )
                        },
                        new vlgConditionalStatement()
                        {
                            new vlgAssign(
                                read.Target,
                                vlgAssignType.NonBlocking,
                                read.Source
                            )
                        }
                    },
                }
            };

            _implementation.Block.WithSyncBlock(block);
        }

        public void TDP(
            RAMTemplateData<vlgIdentifier> data_a,
            RAMTemplateData<vlgIdentifier> data_b
        )
        {
            TDP_PORT(data_a, "Port A");
            TDP_PORT(data_b, "Port B");
        }
    }
}
