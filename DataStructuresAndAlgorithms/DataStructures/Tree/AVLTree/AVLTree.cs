namespace DataStructuresAndAlgorithms.DataStructures.Tree.AVLTree;
public class AVLTree
{
    public AVLNode root;

    // Bir düğümün yüksekliğini alır (null ise -1)
    private int GetHeight(AVLNode node)
    {
        if (node == null)
            return -1; // Null düğümün yüksekliği -1
        return node.height;
    }

    // Bir düğümün yüksekliğini günceller
    private void UpdateHeight(AVLNode node)
    {
        if (node != null)
        {
            node.height = 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
        }
    }

    // Bir düğümün denge faktörünü alır
    private int GetBalanceFactor(AVLNode node)
    {
        if (node == null)
            return 0; // Null düğümün denge faktörü 0
        return GetHeight(node.left) - GetHeight(node.right);
    }

    // Sağ Döndürme (LL Durumu için)
    //      y (dengesiz, BF=+2)
    //     / \
    //    x   T3
    //   / \
    //  T1  T2
    // ----------- Sağ Döndürme Sonrası ------------
    //      x
    //     / \
    //    T1  y
    //       / \
    //      T2  T3
    private AVLNode RightRotate(AVLNode y)
    {
        AVLNode x = y.left;
        AVLNode T2 = x.right;

        // Döndürme
        x.right = y;
        y.left = T2;

        // Yükseklikleri güncelle (önce y, sonra x çünkü x artık y'nin üstünde)
        UpdateHeight(y);
        UpdateHeight(x);

        // Yeni kökü döndür (bu alt ağacın yeni kökü x oldu)
        return x;
    }

    // Sol Döndürme (RR Durumu için)
    //    x (dengesiz, BF=-2)
    //   / \
    //  T1  y
    //     / \
    //    T2  T3
    // ----------- Sol Döndürme Sonrası ------------
    //      y
    //     / \
    //    x   T3
    //   / \
    //  T1  T2
    private AVLNode LeftRotate(AVLNode x)
    {
        AVLNode y = x.right;
        AVLNode T2 = y.left;

        // Döndürme
        y.left = x;
        x.right = T2;

        // Yükseklikleri güncelle (önce x, sonra y çünkü y artık x'in üstünde)
        UpdateHeight(x);
        UpdateHeight(y);

        // Yeni kökü döndür (bu alt ağacın yeni kökü y oldu)
        return y;
    }

    // Ağaca yeni bir anahtar ekleyen genel fonksiyon
    public void Insert(int key)
    {
        root = InsertRecursive(root, key);
    }

    // Anahtar eklemek için özyinelemeli yardımcı fonksiyon
    private AVLNode InsertRecursive(AVLNode node, int key)
    {
        // 1. Normal BST Ekleme İşlemi
        if (node == null)
            return (new AVLNode(key)); // Yeni düğümü oluştur ve döndür

        if (key < node.key)
            node.left = InsertRecursive(node.left, key);
        else if (key > node.key)
            node.right = InsertRecursive(node.right, key);
        else // Aynı anahtara sahip düğümler genellikle kabul edilmez veya özel bir şekilde ele alınır
            return node; // Bu örnekte aynı anahtarı eklemiyoruz

        // 2. Düğümün Yüksekliğini Güncelle
        UpdateHeight(node);

        // 3. Bu düğümün Denge Faktörünü Al ve Dengesizlik Durumunu Kontrol Et
        int balance = GetBalanceFactor(node);

        // 4. Eğer düğüm dengesiz hale geldiyse, 4 durum vardır:

        // Sol-Sol Durumu (LL Case)
        //   Denge > 1 (node sola yatkın) ve eklenen anahtar node.left'in soluna gitti
        if (balance > 1 && key < node.left.key) // veya GetBalanceFactor(node.left) >= 0
            return RightRotate(node);

        // Sağ-Sağ Durumu (RR Case)
        //   Denge < -1 (node sağa yatkın) ve eklenen anahtar node.right'ın sağına gitti
        if (balance < -1 && key > node.right.key) // veya GetBalanceFactor(node.right) <= 0
            return LeftRotate(node);

        // Sol-Sağ Durumu (LR Case)
        //   Denge > 1 (node sola yatkın) ve eklenen anahtar node.left'in sağına gitti
        if (balance > 1 && key > node.left.key) // veya GetBalanceFactor(node.left) < 0
        {
            node.left = LeftRotate(node.left); // Önce sol çocuğa sol döndürme
            return RightRotate(node);          // Sonra mevcut düğüme sağ döndürme
        }

        // Sağ-Sol Durumu (RL Case)
        //   Denge < -1 (node sağa yatkın) ve eklenen anahtar node.right'ın soluna gitti
        if (balance < -1 && key < node.right.key) // veya GetBalanceFactor(node.right) > 0
        {
            node.right = RightRotate(node.right); // Önce sağ çocuğa sağ döndürme
            return LeftRotate(node);             // Sonra mevcut düğüme sol döndürme
        }

        // Eğer dengeliyse veya döndürme yapıldıysa güncellenmiş düğümü döndür
        return node;
    }

    // Ağacı InOrder (LNR) şekilde yazdırmak için basit bir yardımcı fonksiyon
    public void PrintInOrder(AVLNode node)
    {
        if (node != null)
        {
            PrintInOrder(node.left);
            Console.Write(node.key + "(BF:" + GetBalanceFactor(node) + ", H:" + GetHeight(node) + ") ");
            PrintInOrder(node.right);
        }
    }


    public void ClearTree()
}
