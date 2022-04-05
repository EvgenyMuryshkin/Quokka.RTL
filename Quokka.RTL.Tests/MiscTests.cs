using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL;
using Quokka.RTL.MemoryTemplates.Generic;
using Quokka.RTL.Verilog;
using Quokka.RTL.VHDL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

            var generator = new GenericRAMTemplates();
            generator.SDP_RF(arch.Declarations, arch.Implementation, "clock", "we", "mem", "w_addr", "w_data", "r_addr", "r_data");

            file.WithArchitecture(arch);
            AssertFile(file);
        }
    }
}
