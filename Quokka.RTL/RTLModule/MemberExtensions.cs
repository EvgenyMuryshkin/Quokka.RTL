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
