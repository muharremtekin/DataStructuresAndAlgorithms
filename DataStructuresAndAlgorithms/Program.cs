using DataStructuresAndAlgorithms.DataStructures.Tree.BinaryTree;

var tree = BinaryTree<int>.GenerateFromEnumerable(new List<int> { 5, 3, 7, 2, 4, 6, 8 });

Console.WriteLine("Pre-order Traversal:");
tree.PreOrderTraversal(tree.Root);

Console.WriteLine("\nIn-order Traversal:");
tree.InOrderTraversal(tree.Root);

Console.WriteLine("\nPost-order Traversal:");

tree.PostOrderTraversal(tree.Root);

Console.WriteLine("\nLevel-order Traversal:");
tree.LevelOrderTraversal(tree.Root);

Console.ReadKey();
