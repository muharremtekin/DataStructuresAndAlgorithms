namespace DataStructuresAndAlgorithms.Algorithms.Sorting;

public class SortingAlgorithms
{
    public static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
            }
        }
    }


    // Ana fonksiyon: Kullanıcının çağıracağı fonksiyon.
    public static void QuickSort(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
        {
            return; // Sıralamaya gerek yok
        }
        QuickSortRecursive(arr, 0, arr.Length - 1);
    }

    // Özyinelemeli Quicksort yardımcı fonksiyonu
    private static void QuickSortRecursive(int[] arr, int low, int high)
    {
        // Temel durum: Alt dizide 1 veya 0 eleman varsa dur.
        if (low < high)
        {
            // Ayırma işlemini yap ve pivotun son indeksini al
            int pivotIndex = Partition(arr, low, high);

            // Pivotun solundaki alt diziyi özyinelemeli olarak sırala
            QuickSortRecursive(arr, low, pivotIndex - 1);

            // Pivotun sağındaki alt diziyi özyinelemeli olarak sırala
            QuickSortRecursive(arr, pivotIndex + 1, high);
        }
    }

    // Lomuto ayırma (partition) şemasını uygulayan fonksiyon
    private static int Partition(int[] arr, int low, int high)
    {
        // Pivot olarak son elemanı seçelim
        int pivot = arr[high];

        // Daha küçük elemanın indeksi (başlangıçta low'dan bir eksik)
        int i = (low - 1);

        // low'dan high-1'e kadar olan elemanları kontrol et
        for (int j = low; j < high; j++)
        {
            // Eğer mevcut eleman (arr[j]) pivottan küçük veya eşitse
            if (arr[j] <= pivot)
            {
                i++; // Küçük eleman indeksini artır
                Swap(arr, i, j); // Küçük elemanı bulduğumuz yere taşı (arr[i] ile arr[j]'yi değiştir)
            }
        }

        // Döngü bittiğinde, i+1 indeksi pivotun olması gereken yerdir.
        // Pivotu (arr[high]) bu doğru konuma taşı.
        Swap(arr, i + 1, high);

        // Pivotun yeni indeksini döndür
        return (i + 1);
    }

    // Dizideki iki elemanın yerini değiştiren yardımcı metod
    private static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }



    // Ana fonksiyon: Kullanıcının çağıracağı fonksiyon.
    // Özyinelemeli yardımcı fonksiyonu başlatır.
    public static void MergeSort(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
        {
            return; // Sıralamaya gerek yok
        }
        MergeSortRecursive(arr, 0, arr.Length - 1);
    }

    // Özyinelemeli (Recursive) Bölme İşlemini Yapan Yardımcı Fonksiyon
    private static void MergeSortRecursive(int[] arr, int left, int right)
    {
        // Temel durum: Alt dizide 1 veya 0 eleman varsa, zaten sıralıdır.
        if (left < right)
        {
            // Ortanca indeksi bul (taşmayı önlemek için bu yöntem tercih edilir)
            int middle = left + (right - left) / 2;

            // 1. Sol yarıyı özyinelemeli olarak sırala
            MergeSortRecursive(arr, left, middle);

            // 2. Sağ yarıyı özyinelemeli olarak sırala
            MergeSortRecursive(arr, middle + 1, right);

            // 3. Sıralanmış sol ve sağ yarıları birleştir
            Merge(arr, left, middle, right);
        }
    }

    // İki sıralı alt diziyi (arr[left..middle] ve arr[middle+1..right])
    // tek bir sıralı alt dizi (arr[left..right]) olarak birleştiren fonksiyon
    private static void Merge(int[] arr, int left, int middle, int right)
    {
        // Geçici dizilerin boyutlarını hesapla
        int n1 = middle - left + 1; // Sol alt dizinin boyutu
        int n2 = right - middle;     // Sağ alt dizinin boyutu

        // Geçici dizileri oluştur
        int[] L = new int[n1];
        int[] R = new int[n2];

        // Verileri geçici dizilere kopyala
        for (int i = 0; i < n1; ++i)
            L[i] = arr[left + i];
        for (int j = 0; j < n2; ++j)
            R[j] = arr[middle + 1 + j];

        // ------ Birleştirme İşlemi Başlangıcı ------
        int indexLeft = 0;    // Sol geçici dizinin başlangıç indeksi
        int indexRight = 0;   // Sağ geçici dizinin başlangıç indeksi
        int indexMerged = left; // Birleştirilmiş dizinin (orijinal dizinin ilgili bölümü) başlangıç indeksi

        // Sol ve sağ geçici dizilerde eleman olduğu sürece karşılaştır ve kopyala
        while (indexLeft < n1 && indexRight < n2)
        {
            if (L[indexLeft] <= R[indexRight])
            {
                arr[indexMerged] = L[indexLeft];
                indexLeft++;
            }
            else
            {
                arr[indexMerged] = R[indexRight];
                indexRight++;
            }
            indexMerged++;
        }

        // Eğer sol geçici dizide eleman kaldıysa, onları kopyala
        while (indexLeft < n1)
        {
            arr[indexMerged] = L[indexLeft];
            indexLeft++;
            indexMerged++;
        }

        // Eğer sağ geçici dizide eleman kaldıysa, onları kopyala
        while (indexRight < n2)
        {
            arr[indexMerged] = R[indexRight];
            indexRight++;
            indexMerged++;
        }
        // ------ Birleştirme İşlemi Sonu ------
    }
}
