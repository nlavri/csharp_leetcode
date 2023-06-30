namespace _977_squares_of_sorted_array
{
    internal class Program
    {
        public static int[] SortedSquares(int[] nums)
        {
            var result = new int[nums.Length];

            int l = 0;
            int r = nums.Length - 1;
            int ix = nums.Length - 1;
            while (l <= r)
            {
                var lVal = Math.Abs(nums[l]);
                var rVal = Math.Abs(nums[r]);

                if (lVal < rVal)
                {
                    result[ix--] = rVal * rVal;
                    r--;
                }
                else
                {
                    result[ix--] = lVal * lVal;
                    l++;
                }
            }

            return result;
        }
        
        static void Main(string[] args)
        {
            var result = SortedSquares(new int[] { -4, -1, 0, 3, 10 });
            foreach (var i in result)
                Console.Write(i + " ");

            Console.WriteLine("\r\n=================");
    
            result = SortedSquares(new int[] { -7, -3, 2, 3, 11 });
            foreach (var i in result)
                Console.Write(i + " ");

            Console.WriteLine("\r\n=================");
        }
    }
}