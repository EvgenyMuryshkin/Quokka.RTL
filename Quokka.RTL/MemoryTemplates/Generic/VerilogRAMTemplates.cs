using Quokka.RTL.Verilog;

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

        public void SDP_RF(
            string clock, 
            string writeEnable,
            string ram,
            string write_addr,
            string write_data,
            string read_addr,
            string read_data
            )
        {
            _implementation.Block.WithComment("inferred simple dual port RAM with read-first behaviour");

            var block = new vlgSyncBlock(vlgEdgeType.Pos, clock)
            {
                Block =
                {
                    new vlgIf()
                    {
                        new vlgConditionalStatement(new vlgIdentifierExpression(writeEnable))
                        {
                            new vlgAssign(
                                new vlgIdentifier(ram, new vlgIdentifierExpression(write_addr)),
                                vlgAssignType.NonBlocking,
                                write_data
                            )
                        }
                    },
                    new vlgAssign(
                        read_data,
                        vlgAssignType.NonBlocking,
                        new vlgIdentifierExpression(ram, new vlgIdentifierExpression(read_addr))
                    )
                }
            };

            _implementation.Block.WithSyncBlock(block);
        }

        public void SP_RF(
            string clock,
            string writeEnable,
            string ram,
            string addr,
            string write_data,
            string read_data
            )
        {
            _implementation.Block.WithComment("inferred single port RAM with read-first behaviour");

            var block = new vlgSyncBlock(vlgEdgeType.Pos, clock)
            {
                Block =
                {
                    new vlgIf()
                    {
                        new vlgConditionalStatement(new vlgIdentifierExpression(writeEnable))
                        {
                            new vlgAssign(
                                new vlgIdentifier(ram, new vlgIdentifierExpression(addr)),
                                vlgAssignType.NonBlocking,
                                write_data
                            )
                        }
                    },
                    new vlgAssign(
                        read_data,
                        vlgAssignType.NonBlocking,
                        new vlgIdentifierExpression(ram, new vlgIdentifierExpression(addr))
                    )
                }
            };

            _implementation.Block.WithSyncBlock(block);
        }

        public void SDP_WF(
            string clock,
            string writeEnable,
            string ram,
            string ram_width,
            string write_addr,
            string write_data,
            string read_addr,
            string read_data 
            )
        {
            _implementation.Block.WithComment("inferred simple dual port RAM with write-first behaviour");

            var block = new vlgSyncBlock(vlgEdgeType.Pos, clock)
            {
                Block =
                {
                    new vlgIf()
                    {
                        new vlgConditionalStatement(new vlgIdentifierExpression(writeEnable))
                        {
                            new vlgAssign(
                                new vlgIdentifier(ram, new vlgIdentifierExpression(write_addr)),
                                vlgAssignType.Blocking,
                                write_data
                            )
                        }
                    },
                    new vlgAssign(
                        read_data,
                        vlgAssignType.NonBlocking,
                        new vlgIdentifierExpression(ram, new vlgIdentifierExpression(read_addr))
                    )
                }
            };

            _implementation.Block.WithSyncBlock(block);
        }
        
        public void SP_WF(
            string clock,
            string writeEnable,
            string ram,
            string ram_width,
            string addr,
            string write_data,
            string read_data
            )
        {
            var ramWidth = int.Parse(ram_width);
            var addrReg = $"{addr}_reg";

            _implementation.Block.WithComment("inferred single port RAM with write-first behaviour");
            _implementation.Block.WithLogicSignal(vlgNetType.Reg, vlgSignType.Unsigned, addrReg, ramWidth, null);

            var block = new vlgSyncBlock(vlgEdgeType.Pos, clock)
            {
                Block =
                {
                    new vlgIf()
                    {
                        new vlgConditionalStatement(new vlgIdentifierExpression(writeEnable))
                        {
                            new vlgAssign(
                                new vlgIdentifier(ram, new vlgIdentifierExpression(addr)),
                                vlgAssignType.NonBlocking,
                                write_data
                            )
                        }
                    },
                    new vlgAssign(
                        addrReg,
                        vlgAssignType.NonBlocking,
                        addr
                    )
                }
            };

            _implementation.Block.WithSyncBlock(block);

            _implementation.Block.WithAssign(
                new vlgAssign(
                    read_data,
                    vlgAssignType.Assign,
                    new vlgIdentifierExpression(ram, new vlgIdentifierExpression(addrReg))
                )
            );
        }
        
        public void TDP_PORT(
                string ram,
                string clock,
                string writeEnable,
                string addr,
                string write_data,
                string read_data,
                string comments
            )
        {
            _implementation.Block.WithComment(comments);

            var block = new vlgSyncBlock(vlgEdgeType.Pos, clock)
            {
                Block =
                {
                    new vlgIf()
                    {
                        new vlgConditionalStatement(new vlgIdentifierExpression(writeEnable))
                        {
                            new vlgAssign(
                                new vlgIdentifier(ram, new vlgIdentifierExpression(addr)),
                                vlgAssignType.NonBlocking,
                                write_data
                            ),
                            new vlgAssign(
                                read_data,
                                vlgAssignType.NonBlocking,
                                new vlgIdentifierExpression(write_data)
                            )
                        },
                        new vlgConditionalStatement()
                        {
                            new vlgAssign(
                                read_data,
                                vlgAssignType.NonBlocking,
                                new vlgIdentifierExpression(ram, new vlgIdentifierExpression(addr))
                            )
                        }
                    },
                }
            };

            _implementation.Block.WithSyncBlock(block);
        }

        public void TDP(
            string ram,
            string clock_a,
            string writeEnable_a,
            string addr_a,
            string write_data_a,
            string read_data_a,
            string clock_b,
            string writeEnable_b,
            string addr_b,
            string write_data_b,
            string read_data_b
        )
        {
            TDP_PORT(ram, clock_a, writeEnable_a, addr_a, write_data_a, read_data_a, "Port A");
            TDP_PORT(ram, clock_b, writeEnable_b, addr_b, write_data_b, read_data_b, "Port B");
        }
    }
}
