using Quokka.RTL.Tools;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Quokka.RTL
{
    public class DeepReflectionCopy
    {
        public static object DeepValueCopy(object value, Action<Type> unsupported)
        {
            if (value == null)
                return null;

            var valueType = value.GetType();
            if (RTLModuleHelper.IsSynthesizableArrayType(valueType))
            {
                var elementType = valueType.GetElementType();
                var array = value as Array;
                var result = Array.CreateInstance(elementType, array.Length);

                if (elementType.IsValueType)
                {
                    Array.Copy(array, result, array.Length);
                }
                else
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        result.SetValue(DeepValueCopy(array.GetValue(i), unsupported), i);
                    }
                }
                return result;
            }
            else if(valueType.IsArray)
            {
                throw new Exception();
            }
            else if (valueType.IsStruct())
            {
                return DeepCopy(value);
            }
            else if (value is RTLBitArray bitArray)
            {
                return new RTLBitArray(bitArray);
            }
            else if (valueType.IsGenericType)
            {
                unsupported(valueType);
                return null;
            }
            else if (valueType.IsClass)
            {
                return DeepCopy(value);
            }
            else if (valueType.IsPrimitive)
            {
                return value;
            }
            else if (valueType.IsEnum)
            {
                return value;
            }
            else
            {
                unsupported(valueType);
                return null;
            }
        }

        public static T DeepCopy<T>(T source, T result = default(T))
        {
            if (source == null)
                return default(T);

            var type = source.GetType();

            if (result == null && source is IRTLClonable clonable)
            {
                return (T)clonable.Clone();
            }

            if (result == null)
                result = RTLModuleHelper.Activate<T>(type);

            var props = RTLModuleHelper.RecursiveWritableMembers(type);

            foreach (var prop in props)
            {
                var value = prop.GetValue(source);

                prop.SetValue(result, DeepValueCopy(
                    value, 
                    (valueType) =>
                    {
                        throw new Exception($"Unsupported value type in DeepReflectionCopy: {type.Name}.{prop.Name}[{valueType}]");
                    }));
            }

            return result;
        }
    }
}
