using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Quokka.RTL;
using Quokka.VCD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.Reflection
{
    public static class MemberExtensions
    {
        public static object GetValue(this MemberInfo member, object target)
        {
            switch (member)
            {
                case PropertyInfo p: return p.GetValue(target);
                case FieldInfo f: return f.GetValue(target);
                default: throw new InvalidOperationException();
            }
        }

        public static void SetValue(this MemberInfo member, object target, object value)
        {
            switch (member)
            {
                case PropertyInfo p: 
                    p.SetValue(target, value); 
                    break;
                case FieldInfo f: 
                    f.SetValue(target, value); 
                    break;
                default: 
                    throw new InvalidOperationException();
            }
        }

        public static Type GetMemberType(this MemberInfo member)
        {
            switch (member)
            {
                case PropertyInfo p: return p.PropertyType;
                case FieldInfo f: return f.FieldType;
                default: throw new InvalidOperationException();
            }
        }

        public static bool IsPublic(this MemberInfo member)
        {
            switch (member)
            {
                case PropertyInfo p: return p.GetGetMethod()?.IsPublic ?? false;
                case FieldInfo f: return f.IsPublic;
                default: throw new InvalidOperationException();
            }
        }

        public static bool IsAbstract(this MemberInfo member)
        {
            switch (member)
            {
                case PropertyInfo p: return (p.GetGetMethod()?.IsAbstract ?? false) || (p.GetSetMethod()?.IsAbstract ?? false);
                case FieldInfo f: return false;
                default: throw new InvalidOperationException();
            }
        }
    }
}

namespace Quokka.RTL
{
    public static class RTLModuleHelper
    {
        public static bool IsToolkitType(Type type)
        {
            if (type.IsConstructedGenericType)
                return IsToolkitType(type.GetGenericTypeDefinition());

            return type == typeof(RTLCombinationalModule<>) || type == typeof(RTLSynchronousModule<,>);
        }

        public static IEnumerable<MemberInfo> SynthesizableMembers(Type type)
        {
            if (type == null || type == typeof(object) || IsToolkitType(type)) 
                return Enumerable.Empty<MemberInfo>();

            var baseMembers = SynthesizableMembers(type.BaseType);

            var props = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OfType<MemberInfo>();
            var fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OfType<MemberInfo>();

            return baseMembers
                .Concat(props)
                .Concat(fields)
                .Where(p => !p.IsAbstract())
                .Where(p => p.GetCustomAttribute<CompilerGeneratedAttribute>() == null);
        }

        public static List<MemberInfo> ModuleProperties(Type type)
        {
            return SynthesizableMembers(type)
                .Where(m => typeof(IRTLCombinationalModule).IsAssignableFrom(m.GetMemberType()))
                .ToList();
        }
        public static bool IsInternalProperty(MemberInfo memberInfo)
        {
            var isPublic = memberInfo.IsPublic();
            var isPropertyOrField = memberInfo is FieldInfo || memberInfo is PropertyInfo;
            var isToolkitType = IsToolkitType(memberInfo.DeclaringType);
            var isArray = memberInfo.GetMemberType().IsArray;

            return isArray || !isPublic && isPropertyOrField && !isToolkitType;
        }

        public static bool IsSynthesizableSignalType(Type type)
        {
            return type.IsValueType || type == typeof(RTLBitArray);
        }

        public static bool IsSynthesizableArrayType(Type type)
        {
            return type.IsArray && IsSynthesizableSignalType(type.GetElementType());
        }

        public static List<MemberInfo> SignalProperties(Type type)
        {
            return SynthesizableMembers(type)
                .Where(m => IsSynthesizableSignalType(m.GetMemberType()) || IsSynthesizableArrayType(m.GetMemberType()))
                .ToList();
        }

        public static List<MemberInfo> OutputProperties(Type type)
        {
            return SignalProperties(type).Where(p => !IsInternalProperty(p)).ToList();
        }

        public static List<MemberInfo> InternalProperties(Type type)
        {
            return SignalProperties(type).Where(p => IsInternalProperty(p)).ToList();
        }

        public static int SizeOfEnum(Type enumType)
        {
            var values = Enum.GetValues(enumType);

            // defaults to single bit variable
            if (values.Length == 0)
                return 1;

            var maxValue = Enumerable
                .Range(0, values.Length)
                .Select(idx => (uint)Convert.ChangeType(values.GetValue(idx), typeof(uint)))
                .Max();

            return (int)Math.Max(1, Math.Ceiling(Math.Log(maxValue + 1, 2)));
        }

        public static T BSONCopy<T>(T source)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    using (var writer = new BsonWriter(ms))
                    {
                        var serializer = new JsonSerializer();
                        serializer.Serialize(writer, source);

                        ms.Seek(0, SeekOrigin.Begin);

                        using (var reader = new BsonReader(ms))
                        {
                            return serializer.Deserialize<T>(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var json = JsonConvert.SerializeObject(source, Formatting.Indented);
                throw new Exception($"Failed to make a copy of {source.GetType().Name}: {json}", ex);
            }
        }

        static JsonSerializerSettings typeSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects };
        public static T JSONCopy<T>(T source)
        {
            var str = JsonConvert.SerializeObject(source, typeSettings);
            return JsonConvert.DeserializeObject<T>(str);
        }

        public static T DeepCopy<T>(T source)
        {
            return JSONCopy(source);
        }
    }
}
