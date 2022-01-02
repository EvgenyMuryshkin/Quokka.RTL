using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Quokka.RTL.SourceGenerators
{
    public enum CtorVariantType
    {
        Direct,
        SingleObjct,
        SingleCollection
    }

    public class CtorVariant
    {
        public CtorVariant(
            CtorVariantType ctorVariantType, 
            List<PropertyInfo> props, 
            Type ctorType, 
            Type objectType = null,
            PropertyInfo targetProp = null)
        {
            CtorVariantType = ctorVariantType;
            Props = props;
            CtorType = ctorType;
            ObjectType = objectType;
            TargetProp = targetProp;
        }

        public CtorVariantType CtorVariantType { get; set; }
        public List<PropertyInfo> Props { get; set; }
        public Type CtorType { get; set; }
        public Type ObjectType { get; set; }
        public PropertyInfo TargetProp { get; set; }

        public bool IsSame(CtorVariant v)
        {
            if (Props.Count != v.Props.Count)
                return false;

            var propsCheck = Props.Zip(v.Props, (l, r) => new { l, r, same = l.PropertyType == r.PropertyType });
            if (propsCheck.Any(r => !r.same))
                return false;

            return true;
        }


        public bool IsCommented { get; set; }

        public override string ToString()
        {
            return $"{CtorType.Name}, {CtorVariantType}, ({Props.Select(p => p.ToString()).StringJoin(", ")}), {ObjectType}, {TargetProp}";
        }
    }

    public class ImplicitOperator
    {
        public List<Type> ChainedTypes { get; set; } = new List<Type>();

        Type _targetTypeOverride;
        public Type TargetType
        {
            get => _targetTypeOverride ?? ChainedTypes[0];
            set
            {
                _targetTypeOverride = value;
            }
        }

        public List<MethodParam> Params { get; set; } = new List<MethodParam>();
        public List<string> Args { get; set; } = new List<string>();

        public string ParamsLine => Params.Select(p => $"{p.ParamType} {p.ParamName}").ToCSV();
        public string ArgsLine => Args.ToCSV();

        public override string ToString()
        {
            return $"{TargetType.Name}, ({ParamsLine}), ({ArgsLine})";
        }
    }
}
