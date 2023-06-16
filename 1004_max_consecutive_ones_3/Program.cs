namespace _1004_max_consecutive_ones_3
{
    internal class Program
    {
        public static int LongestOnes(int[] nums, int k)
        {
            var best = 0;
            var l = 0;
            var r = 0;
            var zeroCnt = 0;

            while (r < nums.Length)
            {
                var currVal = nums[r];
                if (currVal == 0)
                    zeroCnt++;

                while (zeroCnt > k)
                {
                    if (nums[l] == 0)
                        zeroCnt--;
                    l++;
                }
                best = Math.Max(best, r - l + 1);
                r++;
            }

            return best;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(LongestOnes(new[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, 2));//6
            Console.WriteLine(LongestOnes(new[] { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 }, 3));//10
        }
    }
}