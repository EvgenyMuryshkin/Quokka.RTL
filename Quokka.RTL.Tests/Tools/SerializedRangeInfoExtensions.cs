using Quokka.RTL.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Quokka.RTL.Tests
{
    static class SerializedRangeInfoExtensions
    {
        public static List<SerializedRangeInfo> FromExpression(Expression source)
        {
            switch (source)
            {
                case ParameterExpression pe:
                    return new List<SerializedRangeInfo>();
                case ConstantExpression ce:
                    return new List<SerializedRangeInfo>() { int.Parse(ce.Value.ToString()) };
                case BinaryExpression e:
                    {
                        var left = FromExpression(e.Left);
                        var right = FromExpression(e.Right);
                        return left.Concat(right).ToList();
                    }
                case MemberExpression e:
                    {
                        var result = FromExpression(e.Expression);
                        result.Add(e.Member);
                        return result;
                    }
                default:
                    return new List<SerializedRangeInfo>();
            }
        }

        public static List<SerializedRangeInfo> FromExpression<TSource, TResult>(this TSource source, Expression<Func<TSource, TResult>> expression)
        {
            var result = new List<SerializedRangeInfo>();
            var raw = FromExpression(expression.Body);
            SerializedRangeInfo last = null;

            for (var i = 0; i < raw.Count; i++)
            {
                var iItem = raw[i];
                if (last == null)
                {
                    last = iItem;
                    result.Add(last);
                }
                else if (last.MemberOnly && iItem.IndexOnly)
                {
                    last.Index = iItem.Index;
                }
                else
                {
                    last = iItem;
                    result.Add(last);
                }
            }

            return result;
        }
    }
}
