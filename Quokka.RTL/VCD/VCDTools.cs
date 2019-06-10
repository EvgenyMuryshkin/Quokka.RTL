using Quokka.RTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quokka.VCD
{
    public static class VCDTools
    {
        public static string FormatScopePrefix(Stack<VCDSignalsSnapshot> hierarchy)
        {
            if (!hierarchy.Any())
                return "";

            return string.Join("", hierarchy.Reverse().Select(s => $"{s.Name}_"));
        }

        static List<VCDVariable> FlatternHierarchy(
            Stack<VCDSignalsSnapshot> hierarchy,
            VCDSignalsSnapshot snapshot)
        {
            var result = new List<VCDVariable>();

            if (snapshot != null)
            {
                hierarchy.Push(snapshot);

                foreach (var v in snapshot.Variables)
                {
                    var flat = new VCDVariable($"{FormatScopePrefix(hierarchy)}{v.Name}", v.Value, v.Size, v.Type);
                    result.Add(flat);
                }

                foreach (var scope in snapshot.Scopes)
                    result.AddRange(FlatternHierarchy(hierarchy, scope));

                hierarchy.Pop();
            }

            return result;
        }

        public static List<VCDVariable> FlatternHierarchy(VCDSignalsSnapshot snapshot)
        {
            return FlatternHierarchy(new Stack<VCDSignalsSnapshot>(), snapshot);
        }
    }
}
