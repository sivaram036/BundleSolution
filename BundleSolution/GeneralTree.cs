namespace BundleSolution
{
    /// <summary>
    /// Tree which is used to hold the Bundles & parts information
    /// </summary>
    /// <typeparam name="T">For bundles scenario BundleElement will be the Type</typeparam>
    public class GeneralTree<T> : ITree<T>
    {
        private T Root;
        private List<ITree<T>> Children;

        public GeneralTree(T Root)
        {
            this.Root = Root;
            Children = new List<ITree<T>>();
        }

        /// <summary>
        /// Add sub tree to the tree
        /// </summary>
        /// <param name="subtree">BundleElement type of sub-tree</param>
        public void AddSubTree(ITree<T> subtree)
        {
            Children.Add(subtree);
        }

        /// <summary>
        /// returns the current element is Leaf or not
        /// </summary>
        /// <returns></returns>
        public bool IsLeaf()
        {
            return Children.Count == 0;
        }

        /// <summary>
        /// To get the number of childs/sub-trees
        /// </summary>
        /// <returns>childs count</returns>
        public int NumberSubTrees()
        {
            return Children.Count;
        }

        /// <summary>
        /// To get the children by position
        /// </summary>
        /// <param name="pos">position of the child element</param>
        /// <returns>child element</returns>
        public ITree<T> GetChildren(int pos)
        {
            return Children.ElementAt(pos);
        }

        /// <summary>
        /// To fetch the current root element
        /// </summary>
        /// <returns></returns>
        public T GetRoot()
        {
            return Root;
        }
    }
}
