namespace DataStructuresAndAlgorithms.DataStructures.Tree.AVLTree;

public class AVLNode
{
    public int key;      // Düğümün anahtar değeri
    public int height;   // Düğümün ağaçtaki yüksekliği
    public AVLNode left;   // Sol çocuk
    public AVLNode right;  // Sağ çocuk

    public AVLNode(int d)
    {
        key = d;
        height = 0; // Yeni bir düğüm (yaprak) başlangıçta 0 yüksekliğindedir
                    // (Null çocukların yüksekliği -1 kabul edilir)
        left = null;
        right = null;
    }
}