using System;
namespace BundleSolution.Model
{
    public class BundleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Units { get; set; }
        public int Inventory { get; set; }

        public int? ParentId { get; set; }
    }
}
