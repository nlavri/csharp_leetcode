namespace _283_move_zeroes
{
    internal class Program
    {
        public static void MoveZeroes(int[] nums)
        {
            if (nums.Length == 1)
            {
                return;
            }

            var j = 0;
            var i = 0;

            while (i < nums.Length)
            {
                if (nums[i] == 0)
                {
                    j = i;
                    i += 1;
                    break;
                }
                i += 1;
            }

            while (i < nums.Length)
            {
                if (nums[j] == 0 && nums[i] != 0)
                {
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                    j += 1;
                }
                i += 1;
            }
        }

        static void Main(string[] args)
        {
            var nums = new[] { 0, 1, 0, 3, 12 };

            MoveZeroes(nums);

            foreach (var n in nums)
                Console.WriteLine(n + ",");
        }
    }
}