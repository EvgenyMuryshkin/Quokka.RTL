using Quokka.RTL.Verilog;
using Quokka.RTL.VHDL;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public class ModuleTranslatorResult
    {
        public Dictionary<string, HashSet<object>> Result { get; set; } = new Dictionary<string, HashSet<object>>();

        void EnsureHasKey(string name)
        {
            if (!Result.ContainsKey(name))
                Result[name] = new HashSet<object>();
        }

        public void Add(string name, vlgModuleImplementation implememntation)
        {
            EnsureHasKey(name);
            Result[name].Add(implememntation);
        }

        public void Add(string name, vhdArchitectureImplementation implememntation)
        {
            EnsureHasKey(name);
            Result[name].Add(implememntation);
        }

        public void Add(string name, vhdArchitectureDeclarations declarations)
        {
            EnsureHasKey(name);
            Result[name].Add(declarations);
        }

        public IEnumerable<T> Get<T>(string name)
        {
            if (!Result.TryGetValue(name, out var result))
                result = new HashSet<object>();

            return result.OfType<T>();
        }
    }
}
