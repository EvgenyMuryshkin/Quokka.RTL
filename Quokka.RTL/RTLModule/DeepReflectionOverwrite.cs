using Quokka.RTL.Tools;
using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Quokka.RTL
{
    public class DeepReflectionOverwrite
    {
        public virtual void DeepValueOverwrite(
            object value, 
            Action<object> setResultValue,
            Func<object> getResultValue,
            Action<string, Type> unsupported)
        {
            if (value == null)
            {
                setResultValue(null);
            }

            var valueType = value.GetType();
            if (RTLModuleHelper.IsSynthesizableArrayType(valueType))
            {
                var elementType = valueType.GetElementType();

                var resultValue = getResultValue();

                if (resultValue == null)
                {
                    setResultValue(DeepJSONCopy.DeepCopy(valueType, value));
                }
                else
                {
                    if (valueType.IsArray)
                    {
                        setResultValue(DeepJSONCopy.DeepCopy(valueType, value));

                        //if (elementType.IsValueType)
                        //{
                        //    setResultValue(DeepJSONCopy.DeepCopy(value));
                        //}
                        //else
                        //{
                        //
                        //}

                        //var resultCollection = resultValue as ICollection;
                        //var t = new byte[3];
                        //var resultArray = resultValue as Array;
                    }
                    //else if (valueType.IsList())
                    //{
                    //    var sourceList = valueType as IList;
                    //    var resultList = resultValue as IList;
                    //
                    //    if (sourceList.Count != resultList.Count)
                    //        throw new Exception($"List size mismatch");
                    //}
                    else if (valueType.IsRTLMemoryBlock())
                    {
                        var sourceMemoryBlock = value as IRTLMemoryBlock;
                        elementType = sourceMemoryBlock.ElementType();
                        if (
                            elementType.IsValueType || 
                            elementType.IsRTLBitArray() || 
                            sourceMemoryBlock.IsMarkedForModifications
                        )
                        {
                            var resultMemoryBlock = resultValue as IRTLMemoryBlock;
                            resultMemoryBlock.Stage(sourceMemoryBlock);
                        }
                        else
                        {
                            setResultValue(DeepJSONCopy.DeepCopy(valueType, value));
                        }
                    }
                    else
                    {
                        unsupported(null, valueType);
                    }
                }

/*
                var sourceArray = value as Array;
                var resultArray = value as Array;
                if (resultArray == null)
                {
                    resultArray = Array.CreateInstance(elementType, sourceArray.Length);
                }

                //var result = Array.CreateInstance(elementType, sourceArray.Length);

                if (elementType.IsValueType)
                {
                    Array.Copy(sourceArray, result, sourceArray.Length);
                }
                else
                {
                    for (int i = 0; i < sourceArray.Length; i++)
                    {
                        var indexValue = result.GetValue(i);
                        var indexValue = sourceArray.GetValue(i);
                        DeepOverwrite(value, resultValue);

                        throw new Exception();
                        //result.SetValue(DeepValueCopy(array.GetValue(i), unsupported), i);
                    }
                }
*/
                //return result;
            }
            else if(valueType.IsArray)
            {
                unsupported(null, valueType);
            }
            else if (valueType.IsStruct())
            {
                var resultValue = getResultValue();
                if (resultValue == null)
                {
                    resultValue = DeepReflectionCopy.DeepCopy(valueType, value);
                }
                else
                {
                    DeepOverwrite(value, resultValue);
                }

                setResultValue(resultValue);
            }
            else if (valueType.IsTuple())
            {
                var resultValue = getResultValue();
                if (resultValue == null)
                {
                    resultValue = DeepReflectionCopy.DeepCopy(valueType, value);
                }
                else
                {
                    DeepOverwrite(value, resultValue);
                }
                setResultValue(resultValue);
            }
            else if (value is RTLBitArray bitArray)
            {
                setResultValue(new RTLBitArray(bitArray));
            }
            else if (valueType.IsGenericType)
            {
                unsupported(null, valueType);
            }
            else if (valueType.IsClass)
            {
                var resultValue = getResultValue();
                if (resultValue == null)
                {
                    setResultValue(DeepReflectionCopy.DeepCopy(valueType, value));
                }
                else
                {
                    DeepOverwrite(value, resultValue);
                }
            }
            else if (valueType.IsPrimitive)
            {
                setResultValue(value);
            }
            else if (valueType.IsEnum)
            {
                setResultValue(value);
            }
            else
            {
                unsupported(null, valueType);
            }
        }

        public void DeepOverwrite<T>(T source, T result)
        {
            if (source == null || result == null)
                return;

            var type = source.GetType();

            var props = RTLModuleHelper.RecursiveWritableMembers(type);

            foreach (var prop in props)
            {
                var value = prop.GetValue(source);

                DeepValueOverwrite(
                    value,
                    (newValue) => prop.SetValue(result, newValue),
                    () => prop.GetValue(result),
                    (message, valueType) =>
                    {
                        if (message == null)
                            message = "Unsupported value type in DeepReflectionOverwrite";

                        throw new Exception($"{message}: {type.Name}.{prop.Name}[{valueType}]");
                    }
                );
            }
        }

        public static void Run<T>(T source, T result)
        {
            var d = new DeepReflectionOverwrite();
            d.DeepOverwrite(source, result);
        }
    }
}
