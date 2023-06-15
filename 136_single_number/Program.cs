namespace _136_single_number
{
    internal class Program
    {
        public static int SingleNumber(int[] nums)
        {
            var val = 0;
            foreach (var num in nums)
                val ^= num;
            return val;
        }

        public static int SingleNumber2(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in nums)
                dict[num] = dict.GetValueOrDefault(num) + 1;

            foreach (var kvp in dict)
                if (kvp.Value == 1)
                    return kvp.Key;

            return nums[0];
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(SingleNumber(new[] { 2, 2, 1 }));
            Console.WriteLine(SingleNumber(new[] { 4, 1, 2, 1, 2 }));
            Console.WriteLine(SingleNumber(new[] { 1 }));

            Console.WriteLine(SingleNumber2(new[] { 2, 2, 1 }));
            Console.WriteLine(SingleNumber2(new[] { 4, 1, 2, 1, 2 }));
            Console.WriteLine(SingleNumber2(new[] { 1 }));

            var s = new[] { 2, 1 };
            Array.Sort(s);
        }
    }
}