using Quokka.RTL.VHDL;
using System;
using System.Collections.Generic;
using System.Text;


namespace Quokka.RTL.MemoryTemplates.Generic
{
    public class RAMTemplateReadData<TExpr>
    {
        public List<TExpr> Targets = new List<TExpr>();
        public TExpr Source;
    }

    public class RAMTemplateWriteData<TExpr>
    {
        public TExpr WriteEnable;
        public TExpr Target;
        public List<TExpr> Sources = new List<TExpr>();
    }

    public class RAMTemplateData<TExpr>
    {
        public string Clock;
        public string RAM;
        public int RAMWidth;
        public int RAMDepth;
        public string RegSuffix = "";
        public List<RAMTemplateWriteData<TExpr>> Write = new List<RAMTemplateWriteData<TExpr>>();
        public List<RAMTemplateReadData<TExpr>> Read = new List<RAMTemplateReadData<TExpr>>();
    }


    public abstract class GenericRAMTemplates
    {
        public GenericRAMTemplates()
        {
        }
    }
}
