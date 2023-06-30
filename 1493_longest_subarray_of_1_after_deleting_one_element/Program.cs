namespace _1493_longest_subarray_of_1_after_deleting_one_element
{
    internal class Program
    {
        public static int LongestSubarray(int[] nums)
        {
            int l = 0, r = 0;
            int result = 0;
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
                result = Math.Max(result, r - l + 1);

                r++;
            }
            return result - 1;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(LongestSubarray(new int[] { 1, 1, 0, 1 })); //3
            Console.WriteLine(LongestSubarray(new int[] { 0, 1, 1, 1, 0, 1, 1, 0, 1 })); //5
            Console.WriteLine(LongestSubarray(new int[] { 1, 1, 1 })); //2
        }
    }
}