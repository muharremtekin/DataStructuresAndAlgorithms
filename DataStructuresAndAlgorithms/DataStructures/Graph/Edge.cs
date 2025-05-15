namespace DataStructuresAndAlgorithms.DataStructures.Graph;

// Kenarları ve ağırlıklarını temsil etmek için yardımcı bir sınıf
// (Helper class to represent edges with their weights)
public class Edge<TVertex>
{
    public TVertex TargetVertex { get; } // Kenarın ulaştığı hedef düğüm (Target vertex of the edge)
    public int Weight { get; }          // Kenarın ağırlığı (Weight of the edge)

    public Edge(TVertex targetVertex, int weight)
    {
        TargetVertex = targetVertex;
        Weight = weight;
    }

    // Kolay yazdırma/hata ayıklama için ToString metodu (isteğe bağlı)
    public override string ToString()
    {
        return $"-> {TargetVertex} (Ağırlık: {Weight})";
    }
}
