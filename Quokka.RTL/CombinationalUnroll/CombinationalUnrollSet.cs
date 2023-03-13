using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public class CombinationalUnrollSet
    {
        public List<CombinationalUnrollItem> Items { get; private set; } = new List<CombinationalUnrollItem>();

        public CombinationalUnrollSet()
        {

        }

        public CombinationalUnrollItem Last => Items.Last();

        public void Add(CombinationalUnrollItem item)
        {
            Items.Add(item);
        }

        public void AddRange(IEnumerable<CombinationalUnrollItem> items)
        {
            foreach (var i in items)
                Add(i);
        }

        public string CompletePath
        {
            get
            {
                var result = Items[0].Name;

                foreach (var item in Items.Skip(1))
                {
                    result += $"_{item.Name}";
/*
                    if (item.IsArrayItem)
                    {
                        result += $"{item.Name}";
                    }
                    else
                    {
                        result += $"_{item.Name}";
                    }
*/
                }

                return result;
            }
        }

        public override string ToString()
        {
            return $"{CompletePath}";
        }
    }
}
