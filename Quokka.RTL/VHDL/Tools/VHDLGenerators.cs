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
                case RTLDataType.StdLogic: return vhdDataType.StdLogic;
                default: throw new Exception($"Unsupported type in VHDLGenerators: {type}");
            }
        }
        public vhdSubTypeDeclaration Subtype(RTLBitArray type)
        {
            return new vhdSubTypeDeclaration(
                $"{type.DataType}{type.Size}".ToLower(),
                Map(type.DataType),
                type.Size
            );
        }

        public vhdFunction Compare(RTLBitArray lhs, vhdCompareType compareType, RTLBitArray rhs)
        {
            var lhsType = Subtype(lhs);
            var rhsType = Subtype(rhs);
            var maxWidth = Math.Max(lhs.Size, rhs.Size);
            var result = new vhdFunction()
            {
                Declaration =
                {
                    Name = $"compare_{lhs.DataType}{lhs.Size}_{compareType}_{rhs.DataType}{rhs.Size}".ToLower(),
                    DataType = vhdDataType.StdLogic,
                    Width = 1
                },
                TypeDeclarations =
                {
                    lhsType,
                    rhsType
                },
                Interface =
                {
                    new vhdFunctionCustomPortDeclaration("lhs", lhsType.Name),
                    new vhdFunctionCustomPortDeclaration("rhs", rhsType.Name),
                },
                Variables =
                {
                    new vhdDefaultSignal(vhdNetType.Variable, "lhsSigned", Map(RTLDataType.Signed), maxWidth + 1),
                    new vhdDefaultSignal(vhdNetType.Variable, "rhsSigned", Map(RTLDataType.Signed), maxWidth + 1),
                    new vhdDefaultSignal(vhdNetType.Variable, "result", Map(RTLDataType.StdLogic), 1),
                },
                Implementation =
                {
                    new vhdAssignExpression(
                        "lhsSigned",
                        vhdAssignType.Variable,
                        new vhdProcedureCallExpression(
                            "signed",
                            new vhdProcedureCallExpression("resize", "lhs", $"{maxWidth + 1}")
                        )
                    ),
                    new vhdAssignExpression(
                        "rhsSigned",
                        vhdAssignType.Variable,
                        new vhdProcedureCallExpression(
                            "signed",
                            new vhdProcedureCallExpression("resize", "rhs", $"{maxWidth + 1}")
                        )
                    ),
                    new vhdIf()
                    {
                        new vhdConditionalStatement(new vhdCompareExpression("lhsSigned", compareType, "rhsSigned"))
                        {
                            new vhdAssignExpression("result", vhdAssignType.Variable, "'1'")
                        },
                        new vhdConditionalStatement()
                        {
                            new vhdAssignExpression("result", vhdAssignType.Variable, "'0'")
                        }
                    },
                    new vhdReturnExpression("result")
                }
            };

            return result;
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
                    new vhdFunctionPortDeclaration("condition", vhdDataType.Boolean, 1),
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
                        Width = 1
                    },
                    Interface =
                    {
                        new vhdFunctionPortDeclaration(nameof(source), Map(source.DataType), source.Size)
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
                        Width = 1
                    },
                    Interface =
                    {
                        new vhdFunctionPortDeclaration(nameof(source), Map(source.DataType), source.Size)
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
