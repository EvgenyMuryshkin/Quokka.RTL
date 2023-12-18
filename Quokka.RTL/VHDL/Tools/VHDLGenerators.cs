using Quokka.RTL.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.VHDL.Tools
{
    public class VHDLGenerators
    {
        vhdDataType Map(RTLDataType type)
        {
            switch (type)
            {
                case RTLDataType.Signed: return vhdDataType.Signed;
                case RTLDataType.Unsigned: return vhdDataType.Unsigned;
                default: throw new Exception($"Unsupported type in VHDLGenerators: {type}");
            }
        }
        public vhdSubTypeDeclaration Subtype(RTLBitArray type)
        {
            return new vhdSubTypeDeclaration(
                $"{type.DataType}{type.Size}".ToLower(),
                Map(type.DataType),
                vhdSignalType.Auto,
                type.Size
            );
        }

        public vhdFunction Ternary(RTLBitArray whenTrue, RTLBitArray whenFalse)
        {
            var whenTrueType = Subtype(whenTrue);
            var whenFalseType = Subtype(whenFalse);

            var result = new vhdFunction()
            {
                Declaration =
                {
                    Name = $"ternary_{whenTrue.DataType}_{whenTrue.Size}".ToLower(),
                    DataType = Map(whenTrue.DataType),
                    SignalType = vhdSignalType.Auto,
                    Width = whenTrue.Size,
                    CustomType = whenTrueType.Name
                },
                TypeDeclarations =
                {
                    whenTrueType,
                    whenFalseType
                },
                Interface =
                {
                    new vhdFunctionPortDeclaration("condition", vhdDataType.Boolean, vhdSignalType.Auto, 1),
                    new vhdFunctionCustomPortDeclaration("whenTrue", whenTrueType.Name),
                    new vhdFunctionCustomPortDeclaration("whenFalse", whenFalseType.Name),
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

        public vhdFunction ToBoolean(RTLBitArray source)
        {
            if (source.Size == 1)
            {
                var result = new vhdFunction()
                {
                    Declaration =
                    {
                        Name = $"bit_to_boolean".ToLower(),
                        DataType = vhdDataType.Boolean,
                        SignalType = vhdSignalType.Auto,
                        Width = 1
                    },
                    Interface =
                    {
                        new vhdFunctionPortDeclaration(nameof(source), Map(source.DataType), vhdSignalType.Auto, source.Size)
                    },
                    Implementation =
                    {
                        new vhdReturnExpression(
                            new vhdCompareExpression(nameof(source), vhdCompareType.NotEqual, new RTLBitArray(0).Resized(1))
                        )
                    }
                };

                return result;
            }
            else
            {
                var result = new vhdFunction()
                {
                    Declaration =
                    {
                        Name = $"{source.DataType}_to_boolean".ToLower(),
                        DataType = vhdDataType.Boolean,
                        SignalType = vhdSignalType.Auto,
                        Width = 1
                    },
                    Interface =
                    {
                        new vhdFunctionPortDeclaration(nameof(source), Map(source.DataType), vhdSignalType.Auto, source.Size)
                    },
                    Implementation =
                    {
                        new vhdReturnExpression(
                            new vhdCompareExpression(nameof(source), vhdCompareType.NotEqual, new vhdIdentifierExpression("0"))
                        )
                    }
                };

                return result;
            }
        }

        public vhdFunction Resize(RTLBitArray source, RTLBitArray target)
        {
            var sourceType = Subtype(source);
            var targetType = Subtype(target);

            var result = new vhdFunction()
            {
                Declaration =
                {
                    Name = $"resize_{source.DataType}_{source.Size}_{target.Size}".ToLower(),
                    DataType = Map(source.DataType),
                    SignalType = vhdSignalType.Auto,
                    Width = target.Size,
                    CustomType = targetType.Name
                },
                TypeDeclarations =
                {
                    sourceType, 
                    targetType,
                },
                Interface =
                {
                    new vhdFunctionCustomPortDeclaration(nameof(source), sourceType.Name)
                }
            };

            if (source.Size == 1)
            {
                result.Implementation.Add(
                    new vhdReturnExpression(
                    new vhdAggregate()
                        {
                            new vhdAggregateBitConnection(0, nameof(source)),
                            new vhdAggregateOthersConnection(false)
                        }
                    )
                );
            }
            else
            {
                result.Implementation.Add(
                    new vhdReturnExpression(
                        new vhdProcedureCallExpression("resize", nameof(source), target.Size.ToString())
                    )
                );
            }

            return result;
        }
    }
}
