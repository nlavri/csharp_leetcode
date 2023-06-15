namespace _15_3sum
{
    internal class Program
    {
        static void TwoSum(int[] nums, int i, IList<IList<int>> result)
        {
            var l = i + 1;
            var h = nums.Length - 1;
            while (l < h)
            {
                var sum = nums[i] + nums[l] + nums[h];
                if (sum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[l], nums[h] });
                    l++;
                    h--;
                    while (l < h && nums[l] == nums[l - 1])
                        l++;
                }
                else if (sum > 0)
                    h -= 1;
                else
                    l += 1;
            }
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Array.Sort(nums);

            for (int i = 0; i < nums.Length && nums[i] <= 0; i++)
            {
                if (i == 0 || nums[i - 1] != nums[i])
                    TwoSum(nums, i, result);
            }

            return result;
        }

        static void Main(string[] args)
        {
            var result = ThreeSum(new[] { -1, 0, 1, 2, -1, -4 });
            foreach (var arr in result)
                Console.Write("[" + String.Join(',', arr) + "]\r\n");
            Console.WriteLine("------------------");

            result = ThreeSum(new[] { 0, 1, 1 });
            foreach (var arr in result)
                Console.Write("[" + String.Join(',', arr) + "]\r\n");
            Console.WriteLine("------------------");

            result = ThreeSum(new[] { 0, 0, 0 });
            foreach (var arr in result)
                Console.Write("[" + String.Join(',', arr) + "]\r\n");
            Console.WriteLine("------------------");

            result = ThreeSum(new[] { 0, 0, 0, 0 });
            foreach (var arr in result)
                Console.Write("[" + String.Join(',', arr) + "]\r\n");
            Console.WriteLine("------------------");
        }
    }
}