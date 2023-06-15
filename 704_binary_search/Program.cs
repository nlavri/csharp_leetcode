namespace _704_binary_search
{
    internal class Program
    {
        public static int Search(int[] nums, int target)
        {
            var l = 0;
            var r = nums.Length - 1;
            // [-1,0,3,5,9,12] - 9
            // 0, 5 - 2
            // 3, 5 - 4
            // [-1,0,3,5,9,12] - -1
            // 0, 5 - 2
            // 0, 2 - 1
            // 0, 1
            while (l <= r)
            {
                var mid = (l + r) / 2;
                var midVal = nums[mid];
                if (midVal == target)
                    return mid;
                else if (midVal < target)
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            return -1;
        }

        static void Main(string[] args)
        {

            //4
            Console.WriteLine(Search(new int[] { -1, 0, 3, 5, 9, 12 }, 9));

            //-1
            Console.WriteLine(Search(new int[] { -1, 0, 3, 5, 9, 12 }, 2));

            //0
            Console.WriteLine(Search(new int[] { 5 }, 5));
            Console.WriteLine(Search(new int[] { 1, 3 }, 3));

            Console.WriteLine(Math.Pow(10, 4));
            Console.WriteLine(Math.Pow(2, 31) - 1);
            Console.WriteLine(int.MaxValue);

        }
    }
}