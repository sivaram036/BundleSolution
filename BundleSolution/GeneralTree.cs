namespace BundleSolution
{
    public class GeneralTree<T> : ITree<T>
    {
        private T Root;
        private List<ITree<T>> Children;

        public GeneralTree(T Root)
        {
            this.Root = Root;
            Children = new List<ITree<T>>();
        }

        public void AddSubTree(ITree<T> subtree)
        {
            Children.Add(subtree);
        }

        public List<T> Preorder()
        {
            return PreorderHelper(new List<T>());
        }
        private List<T> PreorderHelper(List<T> result)
        {
            result.Add(Root);
            if (!IsLeaf())
            {
                foreach (ITree<T> subtree in Children)
                {
                    ((GeneralTree<T>)subtree).PreorderHelper(result);
                }
            }
            return result;
        }

        public bool IsLeaf()
        {
            return Children.Count == 0;
        }

        public int NumberSubTrees()
        {
            return Children.Count;
        }

        public ITree<T> GetChildren(int pos)
        {
            return Children.ElementAt(pos);
        }

        public T GetRoot()
        {
            return Root;
        }
    }
}
