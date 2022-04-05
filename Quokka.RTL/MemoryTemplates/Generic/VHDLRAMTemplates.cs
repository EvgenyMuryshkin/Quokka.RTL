using Quokka.RTL.VHDL;


namespace Quokka.RTL.MemoryTemplates.Generic
{
    public class VHDLRAMTemplates : GenericRAMTemplates
    {
        protected readonly vhdArchitectureDeclarations _declarations;
        protected readonly vhdArchitectureImplementation _implementation;

        public VHDLRAMTemplates(vhdArchitectureDeclarations declarations, vhdArchitectureImplementation implementation)
            : base()
        {
            _declarations = declarations;
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
            var block = new vhdGenericBlock()
            {
                new vhdComment("inferred simple dual port RAM with read-first behaviour"),
                new vhdProcess()
                {
                    SensitivityList =
                    {
                        clock,
                        writeEnable,
                        write_addr,
                        write_data,
                        read_addr
                    },
                    Block =
                    {
                        new vhdSyncBlock(vhdEdgeType.Rising, clock)
                        {
                            new vhdIf()
                            {
                                new vhdConditionalStatement(new vhdCompareExpression(writeEnable, vhdCompareType.Equal, "'1'"))
                                {
                                    new vhdAssignExpression(
                                        new vhdIdentifierExpression(ram, new vhdProcedureCallExpression("TO_INTEGER", write_addr)),
                                        vhdAssignType.Signal,
                                        write_data
                                    )
                                }
                            },
                            new vhdAssignExpression(
                                read_data,
                                vhdAssignType.Signal,
                                new vhdIdentifierExpression(ram, new vhdProcedureCallExpression("TO_INTEGER", read_addr))
                            )
                        }
                    }
                }
            };

            _implementation.Block.WithGenericBlock(block);
        }

        public void SP_RF(
            string clock,
            string writeEnable,
            string ram,
            string addr,
            string write_data,
            string read_data,
            string comments = "inferred single port RAM with read-first behaviour"
            )
        {
            var block = new vhdGenericBlock()
            {
                new vhdComment(comments),
                new vhdProcess()
                {
                    SensitivityList =
                    {
                        clock,
                        writeEnable,
                        addr,
                        write_data
                    },
                    Block =
                    {
                        new vhdSyncBlock(vhdEdgeType.Rising, clock)
                        {
                            new vhdIf()
                            {
                                new vhdConditionalStatement(new vhdCompareExpression(writeEnable, vhdCompareType.Equal, "'1'"))
                                {
                                    new vhdAssignExpression(
                                        new vhdIdentifierExpression(ram, new vhdProcedureCallExpression("TO_INTEGER", addr)),
                                        vhdAssignType.Signal,
                                        write_data
                                    )
                                }
                            },
                            new vhdAssignExpression(
                                read_data,
                                vhdAssignType.Signal,
                                new vhdIdentifierExpression(ram, new vhdProcedureCallExpression("TO_INTEGER", addr))
                            )
                        }
                    }
                }
            };

            _implementation.Block.WithGenericBlock(block);
        }

        public void SDP_WF(
            string clock,
            string writeEnable,
            string ram,
            string ram_width,
            string write_addr,
            string write_data,
            string read_addr,
            string read_data,
            string comments = "inferred simple dual port RAM with write-first behaviour"
            )
        {
            var ramWidth = int.Parse(ram_width);
            var readAddrReg = $"{read_addr}_reg";
            _declarations.WithDefaultSignal(vhdNetType.Signal, readAddrReg, vhdDataType.Unsigned, ramWidth);

            var block = new vhdGenericBlock()
            {
                new vhdComment(comments),
                new vhdProcess()
                {
                    SensitivityList =
                    {
                        clock,
                        writeEnable,
                        write_addr,
                        write_data,
                        read_addr
                    },
                    Block =
                    {
                        new vhdSyncBlock(vhdEdgeType.Rising, clock)
                        {
                            new vhdIf()
                            {
                                new vhdConditionalStatement(new vhdCompareExpression(writeEnable, vhdCompareType.Equal, "'1'"))
                                {
                                    new vhdAssignExpression(
                                        new vhdIdentifierExpression(ram, new vhdProcedureCallExpression("TO_INTEGER", write_addr)),
                                        vhdAssignType.Signal,
                                        write_data
                                    )
                                }
                            },
                            new vhdAssignExpression(readAddrReg, vhdAssignType.Signal, read_addr)
                        },
                        new vhdAssignExpression(
                            read_data,
                            vhdAssignType.Signal,
                            new vhdIdentifierExpression(ram, new vhdProcedureCallExpression("TO_INTEGER", readAddrReg))
                        )
                    }
                }
            };

            _implementation.Block.WithGenericBlock(block);
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
            _declarations.WithDefaultSignal(vhdNetType.Signal, addrReg, vhdDataType.Unsigned, ramWidth);

            var block = new vhdGenericBlock()
            {
                new vhdComment("inferred single port RAM with write-first behaviour"),
                new vhdProcess()
                {
                    SensitivityList =
                    {
                        clock,
                        writeEnable,
                        addr,
                        write_data
                    },
                    Block =
                    {
                        new vhdSyncBlock(vhdEdgeType.Rising, clock)
                        {
                            new vhdIf()
                            {
                                new vhdConditionalStatement(new vhdCompareExpression(writeEnable, vhdCompareType.Equal, "'1'"))
                                {
                                    new vhdAssignExpression(
                                        new vhdIdentifierExpression(ram, new vhdProcedureCallExpression("TO_INTEGER", addrReg)),
                                        vhdAssignType.Signal,
                                        write_data
                                    )
                                }
                            },
                            new vhdAssignExpression(addrReg, vhdAssignType.Signal, addr)
                        },
                        new vhdAssignExpression(
                            read_data,
                            vhdAssignType.Signal,
                            new vhdIdentifierExpression(ram, new vhdProcedureCallExpression("TO_INTEGER", addrReg))
                        )
                    }
                }
            };

            _implementation.Block.WithGenericBlock(block);
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
            var block = new vhdGenericBlock()
            {
                new vhdComment(comments),
                new vhdProcess()
                {
                    SensitivityList =
                    {
                        clock,
                        writeEnable,
                        addr,
                        write_data
                    },
                    Block =
                    {
                        new vhdSyncBlock(vhdEdgeType.Rising, clock)
                        {
                            new vhdIf()
                            {
                                new vhdConditionalStatement(new vhdCompareExpression(writeEnable, vhdCompareType.Equal, "'1'"))
                                {
                                    new vhdAssignExpression(
                                        new vhdIdentifierExpression(ram, new vhdProcedureCallExpression("TO_INTEGER", addr)),
                                        vhdAssignType.Variable,
                                        write_data
                                    )
                                }
                            },
                            new vhdAssignExpression(
                                read_data,
                                vhdAssignType.Signal,
                                new vhdIdentifierExpression(ram, new vhdProcedureCallExpression("TO_INTEGER", addr))
                            )
                        }
                    }
                }
            };

            _implementation.Block.WithGenericBlock(block);

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
