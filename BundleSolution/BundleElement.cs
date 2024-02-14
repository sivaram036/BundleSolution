using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleSolution
{
    public class BundleElement
    {
        public string Name { get; set; }
        public int Units { get; set; }
        public int Inventory { get; set; }

        public BundleElement(string name, int units = 1, int inventory = 0)
        {
            Name = name;
            Units = units;
            Inventory = inventory;
        }
    }
}
