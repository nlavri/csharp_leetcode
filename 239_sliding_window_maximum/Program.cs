namespace _239_sliding_window_maximum
{
    internal class Program
    {
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            var result = new int[nums.Length - k + 1];
            var resI = 0;
            var window = new PriorityQueue<(int val, int pos), (int val, int pos)>(Comparer<(int val, int pos)>.Create((x, y) => y.CompareTo(x)));
            int l = 0;
            int r = 0;
            while (r < nums.Length)
            {
                var n = nums[r];
                while (window.Count > 0 && window.Peek().pos < l)
                    window.Dequeue();

                if (r - l < k)
                {
                    window.Enqueue((n, r), (n, r));
                    r++;
                }
                else
                {
                    result[resI++] = window.Peek().val;
                    l++;
                }
            }
            result[resI] = window.Peek().val;
            return result;
        }

        public static int[] MaxSlidingWindow2(int[] nums, int k)
        {
            var comparer = Comparer<(int val, int position)>.Create((x, y) => y.val.CompareTo(x.val));
            var pq = new PriorityQueue<(int val, int position), (int val, int position)>(comparer);
            var res = new int[nums.Length - k + 1];
            int left = 0;
            int right = 0;

            while (right < nums.Length)
            {
                while (pq.Count > 0 && pq.Peek().position < left)
                {
                    pq.Dequeue();
                }

                if (right - left < k)
                {
                    pq.Enqueue((nums[right], right), (nums[right], right));
                    right++;
                }

                if (right - left >= k)
                {
                    res[left++] = nums[pq.Peek().position];
                }

            }

            return res;
        }

        static void Main(string[] args)
        {
            //[3,3,5,5,6,7]
            var result = MaxSlidingWindow(new[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
            foreach (var i in result)
                Console.Write(i + ",");
            Console.WriteLine(Environment.NewLine + "==================");

            //10,10,9,2
            result = MaxSlidingWindow2(new[] { 9, 10, 9, -7, -4, -8, 2, -6 }, 5);
            foreach (var i in result)
                Console.Write(i + ",");
            Console.WriteLine(Environment.NewLine + "==================");

            var dict = new Dictionary<char, int>();
            dict['c'] = 0;
            dict['c']++;
        }
    }
}