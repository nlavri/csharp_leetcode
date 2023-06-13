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
        }

        private static List<int> FindKClosest(int[] ints, int k, int x)
        {
            var result = new List<int>();
            int left = 0;
            int right = ints.Length - 1;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (ints[mid] >= x)
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
                if (right == ints.Length)
                {
                    left--;
                    continue;
                }
                if (Math.Abs(ints[left] - x) <= Math.Abs(ints[right] - x))
                    left--;
                else
                    right++;
            }

            for (int i = left + 1; i < right; i++)
                result.Add(ints[i]);

            return result;
        }
    }
}