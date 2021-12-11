using System;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL.SourceGenerators
{
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
    }
}
