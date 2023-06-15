namespace _33_search_in_rotated_sorted_array
{
    internal class Program
    {
        public static int FindPivot(int[] nums)
        {
            var l = 0;
            var r = nums.Length - 1;
            if (nums[l] < nums[r])
                return 0;

            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var midValue = nums[mid];
                if (midValue > nums[mid + 1])
                {
                    return mid + 1;
                }
                if (midValue < nums[l])
                    r = mid - 1;
                else
                    l = mid + 1;
            }

            return 0;
        }

        public static  int SearchInternal(int[] nums, int target)
        {
            var l = 0;
            var r = nums.Length - 1;

            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var midValue = nums[mid];
                if (midValue == target)
                    return mid;
                if (midValue < target)
                    l = mid + 1;
                else
                    r = mid - 1;
            }

            return -1;
        }

        public static int Search2(int[] nums, int target)
        {
            if (nums.Length == 0)
                return -1;
            if (nums.Length == 1)
                return nums[0] == target ? 0 : -1;

            var pivot = FindPivot(nums);

            var pivotVal = nums[pivot];
            if (pivotVal == target)
                return pivot;
            if (pivot == 0)
                return SearchInternal(nums, target);
            if (nums[0] > target)
            {
                var tRes = SearchInternal(nums[pivot..], target);
                return tRes == -1 ? tRes : tRes + pivot;
            }

            return SearchInternal(nums[..pivot], target);
        }

        public static int Search(int[] nums, int target)
        {
            if (nums.Length == 0)
                return -1;
            if (nums.Length == 1)
                return nums[0] == target ? 0 : -1;

            var l = 0;
            var r = nums.Length - 1;

            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var midValue = nums[mid];
                if (midValue == target)
                    return mid;
                if (nums[l] <= midValue)
                {
                    if (nums[l] <= target && target < midValue)
                        r = mid - 1;
                    else
                        l = mid + 1;
                }
                else
                {
                    if (midValue < target && target <= nums[r])
                        l = mid + 1;
                    else
                        r = mid - 1;
                }
            }

            return -1;
        }

        static void Main(string[] args)
        {

            Console.WriteLine(Search(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0));
            Console.WriteLine(Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0));
            Console.WriteLine(Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 4));
            Console.WriteLine(Search(new int[] { 5, 1, 3 }, 3));

            Console.WriteLine(Search2(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0));
            Console.WriteLine(Search2(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0));
            Console.WriteLine(Search2(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 4));
            Console.WriteLine(Search2(new int[] { 5, 1, 3 }, 3));
        }
    }
}