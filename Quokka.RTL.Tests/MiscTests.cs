using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL;
using Quokka.RTL.MemoryTemplates.Generic;
using Quokka.RTL.Verilog;
using Quokka.RTL.VHDL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.VHDL
{
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
