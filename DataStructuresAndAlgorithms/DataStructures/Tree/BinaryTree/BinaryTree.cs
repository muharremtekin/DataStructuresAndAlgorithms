namespace DataStructuresAndAlgorithms.DataStructures.Tree.BinaryTree;
public class BinaryTree<T> where T : IComparable<T>
{
    public BinaryTreeNode<T> Root { get; set; }
    public BinaryTree()
    {
        Root = null;
    }
    public void Add(T value)
    {
        if (Root == null)
        {
            Root = new BinaryTreeNode<T>(value);
        }
        else
        {
            AddRecursive(Root, value);
        }
    }
    private void AddRecursive(BinaryTreeNode<T> node, T value)
    {
        if (value.CompareTo(node.Value) < 0)
        {
            if (node.Left == null)
            {
                node.Left = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddRecursive(node.Left, value);
            }
        }
        else
        {
            if (node.Right == null)
            {
                node.Right = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddRecursive(node.Right, value);
            }
        }
    }

    public static BinaryTree<T> GenerateFromEnumerable(IEnumerable<T> values)
    {
        BinaryTree<T> tree = new BinaryTree<T>();
        foreach (var value in values)
        {
            tree.Add(value);
        }
        return tree;
    }

    public void PreOrderTraversal(BinaryTreeNode<T> node)
    {
        if (node != null) return;

        Console.Write(node.Value + " ");
        PreOrderTraversal(node.Left);
        PreOrderTraversal(node.Right);

    }

    public void InOrderTraversal(BinaryTreeNode<T> node)
    {
        if (node != null) return;
        InOrderTraversal(node.Left);
        Console.Write(node.Value + " ");
        InOrderTraversal(node.Right);
    }

    public void PostOrderTraversal(BinaryTreeNode<T> node)
    {
        if (node != null) return;
        PostOrderTraversal(node.Left);
        PostOrderTraversal(node.Right);
        Console.Write(node.Value + " ");
    }

    public void LevelOrderTraversal(BinaryTreeNode<T> node)
    {
        if (node == null) return;
        Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
        queue.Enqueue(node);
        while (queue.Count > 0)
        {
            BinaryTreeNode<T> current = queue.Dequeue();
            Console.Write(current.Value + " ");
            if (current.Left != null)
                queue.Enqueue(current.Left);
            if (current.Right != null)
                queue.Enqueue(current.Right);
        }
    }
}

