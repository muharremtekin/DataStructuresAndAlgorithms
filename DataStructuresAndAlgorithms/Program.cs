

using DataStructuresAndAlgorithms.DataStructures.Graph;

Console.WriteLine("--- Yönsüz Ağırlıklı Integer Graf Testi ---");
Graph<int> weightedIntGraph = new Graph<int>(directed: false);
weightedIntGraph.AddEdge(1, 2, 5); // 1 ile 2 arasında ağırlığı 5 olan kenar
weightedIntGraph.AddEdge(1, 3, 10);
weightedIntGraph.AddEdge(2, 4, 3);
weightedIntGraph.AddEdge(3, 4, 2);
weightedIntGraph.AddEdge(4, 5, 7);
weightedIntGraph.AddVertex(6); // Bağlantısız bir düğüm

Console.WriteLine("Düğüm 1'den başlayarak BFS (ağırlıklar gezinmede dikkate alınmaz):");
weightedIntGraph.BreadthFirstSearch(1, vertex => Console.Write(vertex + " "));
Console.WriteLine();

Console.WriteLine("Düğüm 1'den başlayarak DFS (ağırlıklar gezinmede dikkate alınmaz):");
weightedIntGraph.DepthFirstSearch(1, vertex => Console.Write(vertex + " "));
Console.WriteLine();

Console.WriteLine("\nDüğüm 4'ün kenarları ve ağırlıkları:");
foreach (Edge<int> edge in weightedIntGraph.GetEdgesFromVertex(4))
{
    Console.WriteLine($"- Hedef: {edge.TargetVertex}, Ağırlık: {edge.Weight}");
}

Console.WriteLine("\n--- Yönlü Ağırlıklı String Graf Testi ---");
Graph<string> weightedStringGraph = new Graph<string>(directed: true);
weightedStringGraph.AddEdge("Ankara", "İstanbul", 350); // km cinsinden mesafe
weightedStringGraph.AddEdge("Ankara", "Konya", 200);
weightedStringGraph.AddEdge("İstanbul", "İzmir", 300);
weightedStringGraph.AddEdge("Konya", "İzmir", 280);
weightedStringGraph.AddEdge("İzmir", "Antalya", 320);

Console.WriteLine("\nDüğüm 'Ankara'dan başlayarak DFS:");
weightedStringGraph.DepthFirstSearch("Ankara", city => Console.Write(city + " -> "));
Console.WriteLine("SON");

Console.WriteLine("\nDüğüm 'İstanbul'un kenarları ve ağırlıkları:");
foreach (Edge<string> edge in weightedStringGraph.GetEdgesFromVertex("İstanbul"))
{
    Console.WriteLine($"- Hedef: {edge.TargetVertex}, Mesafe: {edge.Weight} km");
}