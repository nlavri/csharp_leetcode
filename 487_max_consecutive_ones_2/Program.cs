namespace _487_max_consecutive_ones_2
{
    internal class Program
    {
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int best = 0;
            int l = 0;
            int r = 0;
            int zeroCnt = 0;
            while (r < nums.Length)
            {
                if (nums[r] == 0)
                    zeroCnt++;
                
                while (zeroCnt > 1)
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
            Console.WriteLine(FindMaxConsecutiveOnes(new[] { 1, 0, 1, 1, 0 }));
            Console.WriteLine(FindMaxConsecutiveOnes(new[] { 1, 0, 1, 1, 0, 1 }));
        }
    }
}