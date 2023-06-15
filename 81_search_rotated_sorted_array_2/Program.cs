namespace _81_search_rotated_sorted_array_2
{
    internal class Program
    {
        static public bool Search(int[] nums, int target)
        {
            if (nums.Length == 0)
                return false;
            if (nums.Length == 1)
                return nums[0] == target;

            var l = 0;
            var r = nums.Length - 1;

            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var midValue = nums[mid];
                if (midValue == target)
                    return true;
                if (nums[l] < midValue)
                {
                    if (nums[l] <= target && target < midValue)
                        r = mid - 1;
                    else
                        l = mid + 1;
                }
                else if (nums[l] > midValue)
                {
                    if (midValue < target && target <= nums[r])
                        l = mid + 1;
                    else
                        r = mid - 1;
                }
                else
                    l += 1;
            }

            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Search(new[] { 2, 5, 6, 0, 0, 1, 2 }, 0));
            Console.WriteLine(Search(new[] { 2, 5, 6, 0, 0, 1, 2 }, 3));
            Console.WriteLine(Search(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 }, 2));
        }
    }
}