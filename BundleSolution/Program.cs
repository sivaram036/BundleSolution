using BundleSolution;

GeneralTree<BundleElement> bike = new GeneralTree<BundleElement>(new BundleElement("Bike"));
GeneralTree<BundleElement> seat = new GeneralTree<BundleElement>(new BundleElement("Seat", 1, 50));
GeneralTree<BundleElement> pedal = new GeneralTree<BundleElement>(new BundleElement("Pedal", 2, 60));
GeneralTree<BundleElement> wheel = new GeneralTree<BundleElement>(new BundleElement("Wheel", 2));
GeneralTree<BundleElement> frame = new GeneralTree<BundleElement>(new BundleElement("Frame", 1, 60));
GeneralTree<BundleElement> tube = new GeneralTree<BundleElement>(new BundleElement("Tube", 1, 35));

wheel.AddSubTree(frame);
wheel.AddSubTree(tube);
bike.AddSubTree(seat);
bike.AddSubTree(pedal);
bike.AddSubTree(wheel);

Console.WriteLine($"Maximum number of bundles we can construct with Inventory: {ComputeMaxBundleCount(bike)}");

// Compute method to find out the Maximum number of bundles we can construct with Inventory
int ComputeMaxBundleCount(GeneralTree<BundleElement> elements)
{
    if (elements.IsLeaf()) // checking the edge case if the bundle has any parts or not. if not returns Zero
        return elements.GetRoot().Inventory / elements.GetRoot().Units;

    int minBundles = Int32.MaxValue; //Initializing minimum bundle we can construct to Maximum passible value

    return ComputeMaxBundleCountHelper(elements, ref minBundles, 1);
}

//self invoked helper function 
int ComputeMaxBundleCountHelper(GeneralTree<BundleElement> elements, ref int minBundles, int totalUnits)
{
    if (!elements.IsLeaf()) 
    {
        totalUnits = totalUnits * elements.GetRoot().Units; 
    }

    for (int i = 0; i < elements.NumberSubTrees(); i++)
    {
        ComputeMaxBundleCountHelper(((GeneralTree<BundleElement>)elements.GetChildren(i)), ref minBundles, totalUnits);
    }

    var root = elements.GetRoot();

    if (elements.IsLeaf())
    {
        var partStock = root.Inventory / (totalUnits * root.Units);
        if (minBundles > partStock)
            minBundles = partStock;
    }
    return minBundles;
}