using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.SourceGenerators.Verilog;
using System.Diagnostics;

namespace Quokka.RTL.SourceGenerators
{
    [TestClass]
    public class VerilogGenerator : HDLModelGenerator
    {
        protected override string SourcePath => Tools.VerilogSourcePath;

        [TestMethod]
        public void Generate()
        {
            var ctx = new VerilogGeneratorContext();
            ctx.Validate();

            GenerateFile(ctx, VisitorImplementationTemplates, "visitors.implementation.templates", ".Implementation");
            GenerateFile(ctx, VisitorImplementation, "visitors.implementation", ".Implementation");
            GenerateFile(ctx, VisitorInterface, "visitors.interface");
            GenerateFile(ctx, Queries, "queries");
            GenerateFile(ctx, Fluent, "fluent");
            GenerateFile(ctx, AST, "ast");
            GenerateFile(ctx, Implicit, "implicit");
            GenerateFile(ctx, Interfaces, "interface");
            GenerateFile(ctx, Enums, "enums");
        }
    }

    [TestClass]
    public class VHDLGenerator : HDLModelGenerator
    {
        protected override string SourcePath => Tools.VHDLSourcePath;

        [TestMethod]
        public void Generate()
        {
            var ctx = new VHDLGeneratorContext();
            ctx.Validate();

            GenerateFile(ctx, VisitorImplementationTemplates, "visitors.implementation.templates", ".Implementation");
            GenerateFile(ctx, VisitorImplementation, "visitors.implementation", ".Implementation");
            GenerateFile(ctx, VisitorInterface, "visitors.interface");
            GenerateFile(ctx, Queries, "queries");
            GenerateFile(ctx, Fluent, "fluent");
            GenerateFile(ctx, AST, "ast");
            GenerateFile(ctx, Implicit, "implicit");
            GenerateFile(ctx, Interfaces, "interface");
            GenerateFile(ctx, Enums, "enums");
        }
    }
}
