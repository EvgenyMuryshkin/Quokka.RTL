using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Quokka.RTL.Tools
{
    public static class RTLTypeCheck
    {
        public static bool IsToolkitType(Type type)
        {
            if (type == null)
                return false;

            if (type.IsConstructedGenericType)
                return IsToolkitType(type.GetGenericTypeDefinition());

            return type.GetCustomAttribute<RTLToolkitTypeAttribute>(false) != null;
        }

        public static bool IsBaseRTLModuleType(Type type)
        {
            if (type.IsGenericType)
                type = type.GetGenericTypeDefinition();

            if (IsToolkitType(type) && (typeof(IRTLCombinationalModule).IsAssignableFrom(type) || typeof(IRTLSynchronousModule).IsAssignableFrom(type)))
                return true;

            return false;
        }

        public static bool IsDerivedRTLModuleType(Type type)
        {
            if (type.IsGenericType)
                type = type.GetGenericTypeDefinition();

            if (!IsBaseRTLModuleType(type) && (typeof(IRTLCombinationalModule).IsAssignableFrom(type) || typeof(IRTLSynchronousModule).IsAssignableFrom(type)))
                return true;

            return false;
        }

        public static bool IsTuple(Type type)
        {
            return RTLReflectionTools.TryResolveTuple(type, out var _);
        }

        public static bool IsSynthesizableObject(Type type)
        {
            return RTLModuleHelper.IsSynthesizableObject(type) && !IsTuple(type);
        }

        public static bool IsAnonymousType(Type type)
        {
            var hasNullNamespace = type.Namespace == null;
            var isPrivate = !type.IsPublic;
            var isSealed = type.IsSealed;
            var isCompilerGenerated = Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false);
            var hasAnonymousName = type.Name.Contains("AnonymousType");

            return hasNullNamespace && isPrivate && isSealed && isCompilerGenerated && hasAnonymousName;
        }

        public static bool IsTypeSerializable(Type type)
        {
            if (type.IsEnum)
                return true;

            if (PredefinedTypes.TypeInfos.ContainsKey(type))
                return true;

            if (type == typeof(RTLBitArray))
                return true;

            if (RTLModuleHelper.IsSynthesizableArrayType(type))
                return true;

            // TODO: add check for IsSynthesizableObject

            if (RTLReflectionTools.TryGetNullableType(type, out var actualType))
                return IsTypeSerializable(actualType);

            return false;
        }

        static HashSet<Type> signedTypes = new HashSet<Type>()
        {
            typeof(sbyte),
            typeof(short),
            typeof(int),
            typeof(long),
        };

        static HashSet<Type> unsignedTypes = new HashSet<Type>()
        {
            typeof(bool),
            typeof(byte),
            typeof(ushort),
            typeof(uint),
            typeof(ulong),
        };

        public static bool IsNumeric(Type type)
        {
            return signedTypes.Contains(type) || unsignedTypes.Contains(type);
        }

        public static bool IsFloat(Type type)
        {
            return type == typeof(float) || type == typeof(float[]);
        }

        public static bool IsSigned(Type type)
        {
            if (!signedTypes.Contains(type) && !unsignedTypes.Contains(type))
                throw new Exception($"Type {type} does not have sign");

            return signedTypes.Contains(type);
        }

        public static bool IsNative(Type type)
        {
            return type.IsEnum || signedTypes.Contains(type) || unsignedTypes.Contains(type) || type == typeof(float) || type == typeof(RTLBitArray);
        }

        public static bool IsFactoryCreatedModule(Type type)
        {
            if (!IsDerivedRTLModuleType(type))
                return false;

            var delegates = type
                .GetTypeInfo()
                .DeclaredNestedTypes
                .Where(t => typeof(MulticastDelegate).IsAssignableFrom(t))
                .ToList();

            var invokes = delegates.Select(d => d.GetMethod("Invoke")).Where(m => m.ReturnType == type).ToList();
            if (!invokes.Any())
                return false;
            
            return true;
        }
    }
}
