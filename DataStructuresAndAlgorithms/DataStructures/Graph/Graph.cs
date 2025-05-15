namespace DataStructuresAndAlgorithms.DataStructures.Graph;


// T tipi, düğümlerin tipini temsil eder.
public class Graph<T>
{
    // Komşuluk listesi (Adjacency List):
    // Her düğümü (T), komşu düğümlere olan kenarların (Edge<T>) bir listesine eşler.
    // Her Edge<T> nesnesi, bir hedef düğüm ve o kenarın ağırlığını içerir.
    private Dictionary<T, LinkedList<Edge<T>>> adjacencyList;
    private bool isDirected; // Grafın yönlü olup olmadığını belirtir (true ise yönlü)

    // Kurucu Metot (Constructor)
    public Graph(bool directed = false)
    {
        adjacencyList = new Dictionary<T, LinkedList<Edge<T>>>();
        isDirected = directed;
    }

    // Grafiğe bir düğüm (vertex) ekler
    public void AddVertex(T vertex)
    {
        if (!adjacencyList.ContainsKey(vertex))
        {
            adjacencyList[vertex] = new LinkedList<Edge<T>>();
        }
    }

    // Grafiğe ağırlıklı bir kenar (weighted edge) ekler
    // source: kaynak düğüm, destination: hedef düğüm, weight: kenarın ağırlığı
    public void AddEdge(T source, T destination, int weight)
    {
        AddVertex(source);      // Kaynak düğümün grafikte olduğundan emin ol
        AddVertex(destination); // Hedef düğümün grafikte olduğundan emin ol

        // Kaynaktan hedefe doğru ağırlıklı kenarı ekle
        // (Bu basit implementasyonda aynı hedef düğüme birden fazla farklı ağırlıklı kenar eklenebilir.
        //  Eğer belirli bir (kaynak, hedef) çifti için tek bir kenar olmasını istiyorsanız,
        //  eklemeden önce mevcut bir kenarın güncellenip güncellenmeyeceğine karar vermeniz gerekir.)
        adjacencyList[source].AddLast(new Edge<T>(destination, weight));

        // Eğer graf yönsüzse, hedeften kaynağa doğru da aynı ağırlıkta bir kenar ekle
        if (!isDirected)
        {
            adjacencyList[destination].AddLast(new Edge<T>(source, weight));
        }
    }

    // Belirli bir düğümden çıkan tüm kenarları (Edge<T> nesneleri olarak) döndürür
    // (Returns all outgoing edges from a specific vertex)
    public IEnumerable<Edge<T>> GetEdgesFromVertex(T vertex)
    {
        if (adjacencyList.ContainsKey(vertex))
        {
            return adjacencyList[vertex];
        }
        return Enumerable.Empty<Edge<T>>();
    }

    // Belirli bir düğümün sadece komşu düğüm kimliklerini döndürür (ağırlıksız gezinmeler için)
    // (Returns only the identifiers of neighbor vertices for unweighted traversals)
    public IEnumerable<T> GetNeighborVertices(T vertex)
    {
        if (adjacencyList.ContainsKey(vertex))
        {
            return adjacencyList[vertex].Select(edge => edge.TargetVertex);
        }
        return Enumerable.Empty<T>();
    }


    // Grafikteki tüm düğümleri (vertices) döndürür
    public IEnumerable<T> GetVertices()
    {
        return adjacencyList.Keys;
    }

    // Genişlik Öncelikli Arama (Breadth-First Search - BFS)
    // Bu BFS implementasyonu kenar ağırlıklarını dikkate almaz, sadece bağlantıları gezer.
    public void BreadthFirstSearch(T startVertex, Action<T> processVertexAction)
    {
        if (!adjacencyList.ContainsKey(startVertex))
        {
            Console.WriteLine($"Başlangıç düğümü ({startVertex}) grafikte bulunamadı.");
            return;
        }

        var queue = new Queue<T>();
        var visited = new HashSet<T>();

        queue.Enqueue(startVertex);
        visited.Add(startVertex);

        while (queue.Count > 0)
        {
            T currentVertex = queue.Dequeue();
            processVertexAction(currentVertex);

            foreach (Edge<T> edge in adjacencyList[currentVertex]) // Kenarlar üzerinde gezin
            {
                T neighbor = edge.TargetVertex; // Asıl komşu düğümü al
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
    }

    // Derinlik Öncelikli Arama (Depth-First Search - DFS) - Genel Metot
    // Bu DFS implementasyonu da kenar ağırlıklarını dikkate almaz.
    public void DepthFirstSearch(T startVertex, Action<T> processVertexAction)
    {
        if (!adjacencyList.ContainsKey(startVertex))
        {
            Console.WriteLine($"Başlangıç düğümü ({startVertex}) grafikte bulunamadı.");
            return;
        }
        var visited = new HashSet<T>();
        DFSRecursive(startVertex, visited, processVertexAction);
    }

    private void DFSRecursive(T currentVertex, HashSet<T> visited, Action<T> processVertexAction)
    {
        visited.Add(currentVertex);
        processVertexAction(currentVertex);

        foreach (Edge<T> edge in adjacencyList[currentVertex]) // Kenarlar üzerinde gezin
        {
            T neighbor = edge.TargetVertex; // Asıl komşu düğümü al
            if (!visited.Contains(neighbor))
            {
                DFSRecursive(neighbor, visited, processVertexAction);
            }
        }
    }
}
