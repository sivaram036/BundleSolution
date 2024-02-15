using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleSolution.Model
{
    /// <summary>
    /// Genaric Bundle Class
    /// </summary>
    public class BundleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Units { get; set; }
        public int Inventory { get; set; }

        public int? ParentId { get; set; }
    }
}
