using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdProcess : vhdAbstractObject
    {
        public List<vhdIdentifier> SensitivityList { get; set; }

        [NoCtorInit]
        public vhdProcessDeclarations Declarations { get; set; }

        [NoCtorInit]
        public vhdGenericBlock Block { get; set; }
    }
}
