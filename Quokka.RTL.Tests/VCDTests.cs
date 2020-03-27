using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.VCD;
using System.Linq;

namespace Quokka.VCD.Tests
{
    [TestClass]
    public class VCDTests
    {
        [TestMethod]
        public void ImmediateWrite()
        {
            var builder = new VCDBuilder("test.vcd");
            var snapshot = new VCDSignalsSnapshot("TOP");
            var scope = snapshot.Scope("Scope");

            var variables = Enumerable.Range(0, 40).Select(idx =>
            {
                var v = new VCDVariable($"var{idx}", 0, 32, VCDVariableType.Wire);
                scope.Add(v);
                return v;
            }).ToList();

            for (var i = 0; i < 10000; i++)
            {
                foreach (var v in variables)
                {
                    v.Value = i;
                }

                builder.Snapshot(i, snapshot);
            }
        }
    }
}
