using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleSolution
{
    public interface ITree<T>
    {
        void AddSubTree(ITree<T> subtree);
        List<T> Preorder();
        bool IsLeaf();
        int NumberSubTrees();
    }
}
