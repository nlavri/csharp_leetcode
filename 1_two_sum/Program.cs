namespace _1_two_sum
{
    internal class Program
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
                dict[nums[i]] = i;

            for (int i = 0; i < nums.Length; i++)
            {
                var b = target - nums[i];
                if (dict.ContainsKey(b))
                {
                    var bIndex = dict[b];
                    if (bIndex != i)
                        return new[] { i, bIndex };
                }

            }
            return null;
        }

        public static int[] TwoSum2(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var b = target - nums[i];
                if (dict.ContainsKey(b))
                {
                    var bIndex = dict[b];
                    return new[] { bIndex, i };
                }
                dict[nums[i]] = i;
            }

            return null;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(',', TwoSum(new[] { 2, 7, 11, 15 }, 9)));
            Console.WriteLine(String.Join(',', TwoSum(new[] { 3, 2, 4 }, 6)));
            Console.WriteLine(String.Join(',', TwoSum(new[] { 3, 3 }, 6)));
            
            Console.WriteLine(String.Join(',', TwoSum2(new[] { 2, 7, 11, 15 }, 9)));
            Console.WriteLine(String.Join(',', TwoSum2(new[] { 3, 2, 4 }, 6)));
            Console.WriteLine(String.Join(',', TwoSum2(new[] { 3, 3 }, 6)));

            IList<IList<int>> result = new List<IList<int>>();
        }
    }
}