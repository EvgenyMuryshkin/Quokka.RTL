using Quokka.RTL.VHDL;
using System;
using System.Collections.Generic;
using System.Text;


namespace Quokka.RTL.MemoryTemplates.Generic
{
    public class GenericRAMTemplates
    {
        public vhdGenericBlock SDP_RF(
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
                new vhdProcess(clock)
                {
                    Block =
                    {
                        new vhdSyncBlock(vhdEdgeType.Rising, clock)
                        {
                            new vhdIf()
                            {
                                new vhdConditionalStatement(new vhdCompareExpression(writeEnable, vhdCompareType.Equal, "'1'"))
                                {
                                    new vhdAssignExpression(
                                        new vhdIdentifierExpression(
                                            ram,
                                            new vhdRange(new vhdProcedureCallExpression("TO_INTEGER", write_addr))
                                        ),
                                        vhdAssignType.Signal,
                                        write_data
                                    )
                                }
                            },
                            new vhdAssignExpression(
                                read_data,
                                vhdAssignType.Signal,
                                new vhdIdentifierExpression(ram, new vhdRange(read_addr))
                            )
                        }
                    }
                }
            };

            return block;
        }
    }
}
