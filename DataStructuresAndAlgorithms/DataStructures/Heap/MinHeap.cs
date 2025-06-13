namespace DataStructuresAndAlgorithms.DataStructures.Heap;

public class MinHeap
{
    // Yığını bir liste üzerinde saklayacağız.
    private readonly List<int> _elements = new List<int>();

    // İndeks hesaplama metotları
    private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;
    private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
    private int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;

    // Eleman var mı diye kontrol eden yardımcı metotlar
    private bool HasParent(int childIndex) => GetParentIndex(childIndex) >= 0;
    private bool HasLeftChild(int parentIndex) => GetLeftChildIndex(parentIndex) < _elements.Count;
    private bool HasRightChild(int parentIndex) => GetRightChildIndex(parentIndex) < _elements.Count;

    // İndeksteki elemanları getiren metotlar
    private int Parent(int childIndex) => _elements[GetParentIndex(childIndex)];
    private int LeftChild(int parentIndex) => _elements[GetLeftChildIndex(parentIndex)];
    private int RightChild(int parentIndex) => _elements[GetRightChildIndex(parentIndex)];

    // İki elemanın yerini değiştirmek için bir metot
    private void Swap(int indexOne, int indexTwo)
    {
        int temp = _elements[indexOne];
        _elements[indexOne] = _elements[indexTwo];
        _elements[indexTwo] = temp;
    }

    // Ekleme sonrası yığını düzenler
    private void HeapifyUp()
    {
        int index = _elements.Count - 1;
        // Ebeveyni olduğu sürece ve ebeveynin değeri kendinden büyük olduğu sürece
        // yukarı doğru yer değiştir.
        while (HasParent(index) && Parent(index) > _elements[index])
        {
            int parentIndex = GetParentIndex(index);
            Swap(parentIndex, index);
            index = parentIndex; // Bir üst seviyeye çık
        }
    }

    // En tepedeki (en küçük) elemana bakar.
    public int Peek()
    {
        if (_elements.Count == 0) throw new InvalidOperationException("Heap is empty.");
        return _elements[0];
    }

    // Yeni bir eleman ekler.
    public void Add(int element)
    {
        _elements.Add(element); // Önce sona ekle
        HeapifyUp();            // Sonra yukarı taşıyarak yığını düzelt
    }


    // Çıkarma sonrası yığını düzenler
    private void HeapifyDown()
    {
        int index = 0; // Kök'ten başla

        // Aşağı inecek yer olduğu sürece (en azından sol çocuk varsa) devam et
        while (HasLeftChild(index))
        {
            // Başlangıçta en küçük çocuğun sol çocuk olduğunu varsayalım
            int smallerChildIndex = GetLeftChildIndex(index);

            // Eğer sağ çocuk varsa VE sağ çocuk soldan daha küçükse,
            // o zaman en küçük çocuk sağdakidir.
            if (HasRightChild(index) && RightChild(index) < LeftChild(index))
            {
                smallerChildIndex = GetRightChildIndex(index);
            }

            // Eğer ebeveyn, en küçük çocuğundan zaten daha küçükse,
            // yığın özelliği sağlanıyor demektir. Döngüyü kır.
            if (_elements[index] < _elements[smallerChildIndex])
            {
                break;
            }
            else
            {
                // Değilse, ebeveyn ile en küçük çocuğu yer değiştir.
                Swap(index, smallerChildIndex);
            }

            // Bir alt seviyeye in ve oradan devam et.
            index = smallerChildIndex;
        }
    }

    // En tepedeki (en küçük) elemanı çıkarır.
    public int Remove()
    {
        if (_elements.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty.");
        }

        int item = _elements[0]; // Döndüreceğimiz elemanı al
        _elements[0] = _elements[_elements.Count - 1]; // En sondakini en başa taşı
        _elements.RemoveAt(_elements.Count - 1); // En sondaki kopyayı sil

        // Eğer heap boşalmadıysa, yığını düzelt.
        if (_elements.Count > 0)
        {
            HeapifyDown();
        }

        return item;
    }
}
