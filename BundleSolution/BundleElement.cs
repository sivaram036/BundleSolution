namespace BundleSolution
{
    /// <summary>
    /// Genaric Bundle Class
    /// </summary>
    public class BundleElement
    {
        /// <summary>
        /// Represent the Name of the element
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// No of units required to construct the bundle
        /// </summary>
        public int Units { get; set; }

        /// <summary>
        /// Available Inventory
        /// </summary>
        public int Inventory { get; set; }

        public BundleElement(string name, int units = 1, int inventory = 0)
        {
            Name = name;
            Units = units;
            Inventory = inventory;
        }
    }
}
