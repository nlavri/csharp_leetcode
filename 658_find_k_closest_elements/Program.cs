namespace _658_find_k_closest_elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var res = FindKClosest(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 5, 4);
            Console.WriteLine(String.Join(',', res));

            res = FindKClosest(new[] { 1, 2, 3, 4, 5, 7, 8, 9 }, 5, 6);
            Console.WriteLine(String.Join(',', res));

            res = FindKClosest(new[] { 1, 2, 3, 4, 5 }, 4, 3);
            Console.WriteLine(String.Join(',', res));
        }

        private static List<int> FindKClosest(int[] arr, int k, int x)
        {
            var result = new List<int>();
            int left = 0;
            int right = arr.Length - 1;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] >= x)
                    right = mid;
                else
                    left = mid + 1;
            }
            left -= 1;
            right = left + 1;

            while (right - left - 1 < k)
            {
                if (left == -1)
                {
                    right++;
                    continue;
                }
                if (right == arr.Length)
                {
                    left--;
                    continue;
                }
                if (Math.Abs(arr[left] - x) <= Math.Abs(arr[right] - x))
                    left--;
                else
                    right++;
            }

            for (int i = left + 1; i < right; i++)
                result.Add(arr[i]);

            return result;
        }
    }
}