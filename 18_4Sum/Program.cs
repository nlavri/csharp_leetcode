namespace _18_4Sum
{
    internal class Program
    {
        public static IList<IList<int>> TwoSum2(int[] nums, int ix, long target)
        {
            IList<IList<int>> result = null;
            var l = ix;
            var h = nums.Length - 1;
            while (l < h)
            {
                long sum = nums[l] + nums[h];
                if (sum == target)
                {
                    result ??= new List<IList<int>>();
                    result.Add(new List<int> { nums[l], nums[h] });
                    l++; h--;
                    while (l < h && nums[l] == nums[l - 1])
                        l++;
                }
                else if (sum > target)
                    h--;
                else
                    l++;
            }
            return result;
        }

        public static IList<IList<int>>? TwoSum(int[] nums, int ix, long target)
        {
            IList<IList<int>> result = null;
            var set = new HashSet<long>();
            for (int i = ix; i < nums.Length; i++)
            {
                var compl = target - nums[i];
                if (set.Contains(compl))
                {
                    result ??= new List<IList<int>>();
                    result.Add(new List<int> { (int)compl, nums[i] });
                    while (i + 1 < nums.Length && nums[i] == nums[i + 1])
                        i++;
                }
                else
                    set.Add(nums[i]);
            }
            return result;
        }

        public static IList<IList<int>> KSum(int[] nums, int i, int k, long target)
        {
            if (i == nums.Length)
                return null;

            IList<IList<int>> result = new List<IList<int>>();

            var avgTarget = target / k;

            if (nums[i] > avgTarget || avgTarget > nums[nums.Length - 1])
                return result;

            if (k == 2)
                return TwoSum(nums, i, target);

            for (int l = i; l < nums.Length; l++)
            {
                if (l == i || nums[l] != nums[l - 1])
                {
                    var nestedResults = KSum(nums, l + 1, k - 1, target - nums[l]);
                    if (nestedResults != null)
                    {
                        foreach (var nested in nestedResults)
                        {
                            nested.Add(nums[l]);
                            result ??= new List<IList<int>>();
                            result.Add(nested);
                        }
                    }
                }
            }

            return result;
        }

        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);

            return KSum(nums, 0, 4, target);
        }
        
        static void Main(string[] args)
        {
            var result = FourSum(new[] { 1, 0, -1, 0, -2, 2 }, 0);
            foreach (var arr in result)
                Console.Write("[" + String.Join(',', arr) + "]\r\n");
            Console.WriteLine("------------------");

            result = FourSum(new[] { -1000000000, -1000000000, 1000000000, -1000000000, -1000000000 }, 294967296);
            foreach (var arr in result)
                Console.Write("[" + String.Join(',', arr) + "]\r\n");
            Console.WriteLine("------------------");

            var s = "abcdefg";
            for (int i = 0; i <= s.Length - 2; i++)
            {
                Console.WriteLine(s[i..(i + 2)]);
            }
        }
    }
}