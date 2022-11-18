using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL;
using Quokka.RTL.MemoryTemplates.Generic;
using Quokka.RTL.Verilog;
using Quokka.RTL.Verilog.Tools;
using Quokka.RTL.VHDL;
using Quokka.RTL.VHDL.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.Verilog
{
    [TestClass]
    public class VerilogGeneratorsTests
    {
        VerilogGenerators _generators = new VerilogGenerators();

        [TestMethod]
        public void Resize_Signed_Up()
        {
            var func = _generators.Resize(sbyte.MinValue, short.MinValue);
            var code = vlgVerilogWriter.WriteObject(func);
        }

        [TestMethod]
        public void Resize_Signed_Down()
        {
            var func = _generators.Resize(short.MinValue, sbyte.MinValue);
            var code = vlgVerilogWriter.WriteObject(func);
        }

        [TestMethod]
        public void Resize_Unsigned_Up()
        {
            var func = _generators.Resize(byte.MinValue, ushort.MinValue);
            var code = vlgVerilogWriter.WriteObject(func);
        }

        [TestMethod]
        public void Resize_Unsigned_Down()
        {
            var func = _generators.Resize(ushort.MinValue, byte.MinValue);
            var code = vlgVerilogWriter.WriteObject(func);
        }

    }
}

namespace Quokka.VHDL
{
    [TestClass]
    public class VHDLGeneratorsTests
    {
        VHDLGenerators _generators = new VHDLGenerators();

        [TestMethod]
        public void Ternary()
        {
            var function = _generators.Ternary(byte.MinValue, byte.MinValue);
            var code = vhdVHDLWriter.WriteObject(function);
        }
    }

    [TestClass]
    public class vhdWriteTests
    {
        [TestMethod]
        public void vhdEntityInstanceGenericMappings()
        {
            var source = new vhdEntityInstanceGenericMappings().WithEntityInstanceNamedGenericMapping("internal", "external");
            var vhdl = vhdVHDLWriter.WriteObject(source);
        }
    }
}

namespace Quokka.VCD.Tests
{
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void SerializerTest()
        {
        }

        void AssertFile(vhdFile file)
        {
            var hdl1 = vhdVHDLWriter.WriteObject(file);
            var json = DeepJSONCopy.Serialize(file, DeepJSONCopy.indentedTypeSettings);
            var deserialized = DeepJSONCopy.Deserialize<vhdFile>(json);
            var hdl2 = vhdVHDLWriter.WriteObject(deserialized);
            Assert.AreEqual(hdl1, hdl2);
        }

        [TestMethod]
        public void vhdAggregateCtor()
        {
            var file = new vhdFile();
            var arch = new vhdArchitecture();

            var generator = new VHDLRAMTemplates(arch.Declarations, arch.Implementation);
            var templateData = new RAMTemplateData<vhdIdentifier>()
            {
                Clock = "clock",
                Write =
                {
                    new RAMTemplateWriteData<vhdIdentifier>()
                    {
                        WriteEnable = "we",
                        Source = new vhdIdentifier("mem", new vhdRange("w_addr")),
                        Target = "w_data"
                    }
                },
                Read =
                {
                    new RAMTemplateReadData<vhdIdentifier>()
                    {
                        Source = new vhdIdentifier("mem", new vhdRange("r_addr")),
                        Target = "rdata"
                    }
                },
                RAM = "mem",
                RAMDepth = 64,
                RAMWidth = 8,
                RegSuffix = "0"
            };
            generator.SDP_RF(templateData);

            file.WithArchitecture(arch);
            AssertFile(file);
        }
    }
}
