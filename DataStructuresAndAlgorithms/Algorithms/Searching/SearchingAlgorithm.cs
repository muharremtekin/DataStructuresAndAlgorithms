namespace DataStructuresAndAlgorithms.Algorithms.Searching;

public class SearchingAlgorithm
{
    public static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
                return i; // Eleman bulundu, indeksini döndür
        }
        return -1; // Eleman bulunamadı
    }


    public static int BinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // Orta indeksi hesapla

            if (arr[mid] == target)
                return mid; // Eleman bulundu, indeksini döndür
            else if (arr[mid] < target)
                left = mid + 1; // Sağ yarıya geç
            else
                right = mid - 1; // Sol yarıya geç
        }

        return -1; // Eleman bulunamadı
    }


}
