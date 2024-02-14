using BundleSolution;
using System.Security.Cryptography;

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

var result = bike.Preorder();

foreach (var r in result)
{
    Console.WriteLine($"Name - {r.Name}; Units - {r.Units}; Inventory - {r.Inventory};");
}

Console.WriteLine();
Console.WriteLine($"Maximum number of bundles we can construct with Inventory: {ComputeMaxBundleCount(bike)}");

int ComputeMaxBundleCount(GeneralTree<BundleElement> elements)
{
    if (elements.IsLeaf())
        return 0;
    var firstElement = ((GeneralTree<BundleElement>)elements.GetChildren(0)).GetRoot();
    int min = firstElement.Inventory / firstElement.Units;
    return ComputeMaxBundleCountHelper(elements, ref min);
}

int ComputeMaxBundleCountHelper(GeneralTree<BundleElement> elements, ref int min)
{
    for (int i = 0; i < elements.NumberSubTrees(); i++)
    {
        ComputeMaxBundleCountHelper(((GeneralTree<BundleElement>)elements.GetChildren(i)), ref min);
    }

    var root = elements.GetRoot();

    if (elements.IsLeaf())
    {
        var partStock = root.Inventory / root.Units;
        if (min > partStock)
            min = partStock;
    }
    else if(root.Units != 0)
    {
        min = min / root.Units;
    }
    return min;
}