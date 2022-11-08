using Quokka.RTL.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Quokka.RTL.Verilog.Tools
{
    public class VerilogGenerators
    {
        public vlgFunction Resize(RTLBitArray source, RTLBitArray target)
        {
            var result = new vlgFunction(
                $"resize_{source.DataType}_{source.Size}_{target.Size}".ToLower(), 
                target.Size
            );

            result.Interface.WithFunctionPortDeclaration(
                vlgPortDirection.Input,
                vlgNetType.Wire, 
                source.DataType == RTLSignalType.Signed ? vlgSignType.Signed : vlgSignType.Unsigned,
                source.Size,
                nameof(source)
            );

            var extensionSize = target.Size - source.Size;
            if (extensionSize < 0)
            {
                result.Implementation.Block.WithAssign(
                    result.Declaration.Name,
                    vlgAssignType.Equal,
                    new vlgIdentifierExpression(nameof(source), new vlgRange(new vlgIntegerExpression(target.Size - 1), new vlgIntegerExpression(0)))
                );
            }
            else if (extensionSize > 0)
            {
                switch (source.DataType)
                {
                    case RTLSignalType.Signed:
                        result.Implementation.Block.WithAssign(
                            result.Declaration.Name,
                            vlgAssignType.Equal,
                            new vlgAggregateExpression(
                                new vlgSizedAggregateExpression(
                                    extensionSize, 
                                    new vlgIdentifierExpression(nameof(source), new vlgRange(new vlgIntegerExpression(source.Size - 1)))
                                ),
                                nameof(source)
                            )
                        );
                        break;
                    case RTLSignalType.Unsigned:
                        result.Implementation.Block.WithAssign(
                            result.Declaration.Name,
                            vlgAssignType.Equal,
                            new vlgAggregateExpression(
                                new vlgSizedAggregateExpression(extensionSize, new vlgBinaryValueExpression(false)),
                                nameof(source)
                            )
                        );
                        break;
                    default:
                        throw new Exception($"Signal of type {source.DataType} cannot be resized");
                }
            }
            else
            {
                // same size
                result.Implementation.Block.WithAssign(
                    result.Declaration.Name,
                    vlgAssignType.Equal,
                    nameof(source)
                );
            }

            return result;
        }
    }
}
