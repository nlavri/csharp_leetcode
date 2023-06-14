using Xunit;

namespace sorts
{
    internal class Program
    {
        public static int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = 0; j < arr.Length - 1 - i; j++)
                    if (arr[j] > arr[j + 1])
                        (arr[j + 1], arr[j]) = (arr[j], arr[j + 1]);

            return arr;
        }

        public static int[] ShakerSort(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left < right)
            {
                for (int i = right; i > left; i--)
                    if (arr[i - 1] > arr[i])
                        (arr[i - 1], arr[i]) = (arr[i], arr[i - 1]);
                left++;

                for (int i = left; i < right; i++)
                    if (arr[i] > arr[i + 1])
                        (arr[i + 1], arr[i]) = (arr[i], arr[i + 1]);
                right--;
            }

            return arr;
        }

        public static int[] InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var tmp = arr[i];

                int j = i;
                while (j > 0 && arr[j - 1] > tmp)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = tmp;
            }


            return arr;
        }
        public static int[] InsertionSortDesc(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var tmp = arr[i];

                int j = i;
                while (j > 0 && arr[j - 1] < tmp)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = tmp;
            }


            return arr;
        }

        public static int Partition(int[] arr, int l, int r)
        {
            var p = arr[r];
            var less = l;
            for (int i = l; i < r; i++)
            {
                if (arr[i] < p)
                {
                    (arr[i], arr[less]) = (arr[less], arr[i]);
                    less++;
                }
            }
            (arr[r], arr[less]) = (arr[less], arr[r]);
            return less;
        }

        public static void QuickSortInternal(int[] arr, int l, int r)
        {
            if (l >= r) return;

            var p = Partition(arr, l, r);
            QuickSortInternal(arr, l, p - 1);
            QuickSortInternal(arr, p + 1, r);
        }

        public static int[] QuickSort(int[] arr)
        {
            QuickSortInternal(arr, 0, arr.Length - 1);
            return arr;
        }
        private static void MergeSortInternal(int[] arr, int l, int r)
        {
            if (l >= r) return;
            var m = (l + r) / 2;
            MergeSortInternal(arr, l, m);
            MergeSortInternal(arr, m + 1, r);
            var buff = new int[r - l + 1];
            int i = l, j = m + 1, k = 0;
            while (i <= m || j <= r)
            {
                if (i > m)
                    buff[k++] = arr[j++];
                else if (j > r)
                    buff[k++] = arr[i++];
                else if (arr[i] < arr[j])
                    buff[k++] = arr[i++];
                else
                    buff[k++] = arr[j++];
            }
            for (i = 0; i < buff.Length; i++)
                arr[l + i] = buff[i];

        }

        public static int[] MergeSort(int[] arr)
        {
            MergeSortInternal(arr, 0, arr.Length - 1);
            return arr;
        }

        private static void MergeSortInternal2(int[] arr, int[] buff, int l, int r)
        {
            if (l >= r) return;
            var m = (l + r) / 2;
            MergeSortInternal(arr, l, m);
            MergeSortInternal(arr, m + 1, r);
            int i = l, j = m + 1, k = 0;
            while (i <= m || j <= r)
            {
                if (i > m)
                    buff[k++] = arr[j++];
                else if (j > r)
                    buff[k++] = arr[i++];
                else if (arr[i] < arr[j])
                    buff[k++] = arr[i++];
                else
                    buff[k++] = arr[j++];
            }
            for (i = 0; i < buff.Length; i++)
                arr[l + i] = buff[i];

        }

        public static int[] MergeSort2(int[] arr)
        {
            MergeSortInternal2(arr, new int[arr.Length], 0, arr.Length - 1);
            return arr;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(ObjectDumper.Dump(BubbleSort(new[] { 3, 4, 2, 1 })));

            Assert.Equal(new[] { 1, 2, 4, 5 }, BubbleSort(new[] { 1, 4, 2, 5 }));
            Assert.Equal(new[] { 1, 2, 3, 4 }, ShakerSort(new[] { 3, 4, 2, 1 }));
            Assert.Equal(new[] { 1, 2, 3, 4 }, InsertionSort(new[] { 3, 4, 2, 1 }));
            Assert.Equal(new[] { 4, 3, 2, 1 }, InsertionSortDesc(new[] { 1, 2, 4, 3 }));
            Assert.Equal(new[] { 0, 1, 2, 6, 7, 8, 9 }, QuickSort(new[] { 8, 7, 6, 1, 0, 9, 2 }));
            Assert.Equal(new[] { 0, 1, 2, 6, 7, 8, 9 }, MergeSort(new[] { 8, 7, 6, 1, 0, 9, 2 }));
            Assert.Equal(new[] { 0, 1, 2, 6, 7, 8, 9 }, MergeSort2(new[] { 8, 7, 6, 1, 0, 9, 2 }));
        }
    }
}