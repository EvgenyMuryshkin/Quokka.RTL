using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Quokka.RTL
{
    public class DeepDiff
    {
        public static DeepCompareItem DeepCompare(object lhs, object rhs, List<MemberInfo> path = null)
        {
            path = path ?? new List<MemberInfo>();

            if (lhs == null && rhs == null) return null;
            if (lhs == null || rhs == null) return new DeepCompareItem(path, lhs, rhs);

            var lhsType = lhs.GetType();
            var rhsType = rhs.GetType();

            if (lhsType != rhsType)
                return new DeepCompareItem(path, lhs, rhs, $"lhs type {lhsType} is not equal to rhs type {rhsType}");

            foreach (var prop in RTLModuleHelper.SignalProperties(lhs.GetType()))
            {
                var propPath = path.ToList();
                propPath.Add(prop);

                var lhsValue = prop.GetValue(lhs);
                var rhsValue = prop.GetValue(rhs);

                if (lhsValue == null && rhsValue == null)
                    continue;

                if (RTLModuleHelper.IsSynthesizableArrayType(prop.GetMemberType()))
                {
                    if (lhsType.GetElementType() != rhsType.GetElementType())
                        return new DeepCompareItem(propPath, lhsValue, rhsValue, $"lhs array type {lhsType} is not equal to rhs array type {rhsType}");

                    var lhsArray = lhsValue as Array;
                    var rhsArray = rhsValue as Array;

                    if (lhsArray == null && rhsArray == null)
                        continue;

                    if (lhsArray == null || rhsArray == null)
                        return new DeepCompareItem(propPath, lhsValue, rhsValue);

                    if (lhsArray.Length != rhsArray.Length)
                        return new DeepCompareItem(propPath, lhsValue, rhsValue, $"Array length does not match");

                    for (var idx = 0; idx < lhsArray.Length; idx++)
                    {
                        var lhsArrayItem = lhsArray.GetValue(idx);
                        var rhsArrayItem = rhsArray.GetValue(idx);

                        var arrayItemCompare = DeepCompare(lhsArrayItem, rhsArrayItem, propPath);
                        if (arrayItemCompare != null)
                            return new DeepCompareItem(propPath, lhsArrayItem, rhsArrayItem, arrayItemCompare.Messages, $"Element at index {idx} does not match");
                    }
                }
                else if (lhsValue is RTLBitArray)
                {
                    if (!lhsValue.Equals(rhsValue))
                        return new DeepCompareItem(propPath, lhsValue, rhsValue);
                }
                else if (prop.GetMemberType().IsClass)
                {
                    var classCompare = DeepCompare(lhsValue, rhsValue, propPath);
                    if (classCompare != null)
                        return new DeepCompareItem(propPath, lhsValue, rhsValue, classCompare.Messages);
                }
                else
                {
                    if (!lhsValue.Equals(rhsValue))
                        return new DeepCompareItem(propPath, lhsValue, rhsValue);
                }
            }

            return null;
        }

        public static bool DeepEquals(object lhs, object rhs)
        {
            if (lhs == null && rhs == null) return true;
            if (lhs == null || rhs == null) return false;

            var lhsType = lhs.GetType();
            var rhsType = rhs.GetType();

            if (lhsType != rhsType)
                return false;

            var lhsComparable = lhs as IRTLComparable;
            var rhsComparable = rhs as IRTLComparable;

            if (lhsComparable != null && rhsComparable != null)
            {
                return lhsComparable.IsEqual(rhsComparable);
            }

            // TODO: build code generator for type compare

            foreach (var prop in RTLModuleHelper.SignalProperties(lhs.GetType()))
            {
                var lhsValue = prop.GetValue(lhs);
                var rhsValue = prop.GetValue(rhs);

                if (lhsValue == null && rhsValue == null)
                    continue;

                if (RTLModuleHelper.IsSynthesizableArrayType(prop.GetMemberType()))
                {
                    if (lhsType.GetElementType() != rhsType.GetElementType())
                        return false;

                    var lhsArray = lhsValue as Array;
                    var rhsArray = rhsValue as Array;

                    if (lhsArray == null && rhsArray == null)
                        continue;

                    if (lhsArray == null || rhsArray == null)
                        return false;

                    if (lhsArray.Length != rhsArray.Length)
                        return false;

                    for (var idx = 0; idx < lhsArray.Length; idx++)
                    {
                        var lhsArrayItem = lhsArray.GetValue(idx);
                        var rhsArrayItem = rhsArray.GetValue(idx);

                        if (!DeepEquals(lhsArrayItem, rhsArrayItem))
                            return false;
                    }
                }
                else if (lhsValue is RTLBitArray)
                {
                    if (!lhsValue.Equals(rhsValue))
                        return false;
                }
                else if (prop.GetMemberType().IsClass)
                {
                    if (!DeepEquals(lhsValue, rhsValue))
                        return false;
                }
                else
                {
                    if (!lhsValue.Equals(rhsValue))
                        return false;
                }
            }

            return true;
        }
    }
}
