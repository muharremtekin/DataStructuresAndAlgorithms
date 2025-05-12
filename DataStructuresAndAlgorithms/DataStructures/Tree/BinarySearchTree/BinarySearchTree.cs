namespace DataStructuresAndAlgorithms.DataStructures.Tree.BinarySearchTree;
public class BinarySearchTree<T> where T : IComparable<T>
{
    public BSTNode<T> Root { get; set; }

    public BinarySearchTree()
    {
        Root = null;
    }

    public void Insert(T key)
    {
        Root = InsertRecursive(Root, key);
    }

    private BSTNode<T> InsertRecursive(BSTNode<T> currentRoot, T key)
    {
        if (currentRoot == null)
        {
            currentRoot = new BSTNode<T>(key);
            return currentRoot;
        }

        if (key.CompareTo(currentRoot.Value) < 0)
            currentRoot.Left = InsertRecursive(currentRoot.Left, key);
        else if (key.CompareTo(currentRoot.Value) > 0)
            currentRoot.Right = InsertRecursive(currentRoot.Right, key);

        return currentRoot;
    }

    public bool Search(T key)
    {
        return SearchRecursive(Root, key) != null;
    }

    private BSTNode<T> SearchRecursive(BSTNode<T> currentRoot, T key)
    {
        if (currentRoot == null || currentRoot.Value.Equals(key))
            return currentRoot;

        if (key.CompareTo(currentRoot.Value) > 0)
            return SearchRecursive(currentRoot.Right, key);

        return SearchRecursive(currentRoot.Left, key);
    }

    public void Delete(T key)
    {
        Root = DeleteRecursive(Root, key);
    }

    private BSTNode<T> DeleteRecursive(BSTNode<T> currentRoot, T key)
    {
        if (currentRoot == null) return currentRoot;

        if (key.CompareTo(currentRoot.Value) < 0)
            currentRoot.Left = DeleteRecursive(currentRoot.Left, key);
        else if (key.CompareTo(currentRoot.Value) > 0)
            currentRoot.Right = DeleteRecursive(currentRoot.Right, key);
        else
        {
            if (currentRoot.Left == null)
                return currentRoot.Right;
            else if (currentRoot.Right == null)
                return currentRoot.Left;

            currentRoot.Value = FindMinValue(currentRoot.Right);
            currentRoot.Right = DeleteRecursive(currentRoot.Right, currentRoot.Value);
        }
        return currentRoot;
    }

    private T FindMinValue(BSTNode<T> node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }
        return node.Value;
    }

    public void InOrderTraversal(BSTNode<T> node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.Write(node.Value + " ");
            InOrderTraversal(node.Right);
        }
    }
}
