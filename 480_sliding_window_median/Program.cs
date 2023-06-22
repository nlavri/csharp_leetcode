namespace _480_sliding_window_median
{
    internal class Program
    {
        public static double[] MedianSlidingWindow(int[] nums, int k)
        {
            var result = new double[nums.Length - k + 1];
            var window = new List<int>();
            var r = 0;
            var l = 0;
            var resIx = 0;
            var isOdd = k % 2 != 0;
            while (r < nums.Length)
            {
                if (window.Count < k)
                {
                    var val = nums[r++];
                    var ixOfVal = window.BinarySearch(val);
                    if (ixOfVal < 0)
                        ixOfVal = ~ixOfVal;
                    window.Insert(ixOfVal, val);
                }
                if (window.Count == k)
                {
                    result[resIx++] = isOdd ?
                        (double)window[k / 2] :
                        (((double)window[k / 2 - 1] + (double)window[k / 2]) / 2.0);
                    window.Remove(nums[l++]);
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            var result = MedianSlidingWindow(new[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
            foreach (var d in result)
                Console.WriteLine(d);

            Console.WriteLine("\r\n=============");

        }
    }
}