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

    // Traversal methods
    // Pre-order traversal: Root -> Left -> Right
    public void PreOrderTraversal(BinaryTreeNode<T> node)
    {
        if (node is null) return;

        Console.Write(node.Value + " ");
        PreOrderTraversal(node.Left);
        PreOrderTraversal(node.Right);

    }

    // In-order traversal: Left -> Root -> Right
    public void InOrderTraversal(BinaryTreeNode<T> node)
    {
        if (node is null) return;
        InOrderTraversal(node.Left);
        Console.Write(node.Value + " ");
        InOrderTraversal(node.Right);
    }

    // Post-order traversal: Left -> Right -> Root
    public void PostOrderTraversal(BinaryTreeNode<T> node)
    {
        if (node is null) return;
        PostOrderTraversal(node.Left);
        PostOrderTraversal(node.Right);
        Console.Write(node.Value + " ");
    }
    // Level-order traversal is also known as breadth-first traversal.
    // It visits all the nodes at the present depth level before moving on to the nodes at the next depth level.
    public void LevelOrderTraversal(BinaryTreeNode<T> node)
    {
        if (node is null) return;
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


    // Depth-first traversal methods
    // Depth-first traversal is a traversal method that goes as deep as possible down one branch before backing up.
    public void DFS(BinaryTreeNode<T> root)
    {
        if (root is null) return;

        Console.Write(root.Value + " ");

        DFS(root.Left);
        DFS(root.Right);
    }

    // Breadth-first traversal is a traversal method
    // that visits all the nodes at the present depth level before moving on to the nodes at the next depth level.
    public void BFS(BinaryTreeNode<T> root)
    {
        if (root is null) return;
        Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
        queue.Enqueue(root);
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

