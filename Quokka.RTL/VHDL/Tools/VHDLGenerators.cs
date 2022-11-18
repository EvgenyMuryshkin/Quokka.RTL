using Quokka.RTL.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.VHDL.Tools
{
    public class VHDLGenerators
    {
        vhdDataType Map(RTLSignalType type)
        {
            switch (type)
            {
                case RTLSignalType.Signed: return vhdDataType.Signed;
                case RTLSignalType.Unsigned: return vhdDataType.Unsigned;
                default: throw new Exception($"Unsupported type in VHDLGenerators: {type}");
            }
        }
        public vhdFunction Ternary(RTLBitArray whenTrue, RTLBitArray whenFalse)
        {
            var result = new vhdFunction()
            {
                Declaration =
                {
                    Name = $"ternary_{whenTrue.DataType}_{whenTrue.Size}".ToLower(),
                    Type = Map(whenTrue.DataType),
                    Width = whenTrue.Size
                },
                Interface =
                {
                    new vhdFunctionPortDeclaration("condition", vhdDataType.Boolean, 1),
                    new vhdFunctionPortDeclaration("whenTrue", Map(whenTrue.DataType), whenTrue.Size),
                    new vhdFunctionPortDeclaration("whenFalse", Map(whenFalse.DataType), whenFalse.Size),
                },
                Implementation =
                {
                    new vhdIf()
                    {
                        new vhdConditionalStatement("condition")
                        {
                            new vhdReturnExpression("whenTrue")
                        },
                        new vhdConditionalStatement()
                        {
                            new vhdReturnExpression("whenFalse")
                        }
                    }
                }
            };

            return result;
        }
    }
}
