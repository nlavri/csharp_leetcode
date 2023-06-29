namespace _11_container_with_most_water
{
    internal class Program
    {
        public static int MaxArea(int[] height)
        {
            int l = 0;
            int r = height.Length - 1;
            var maxArea = 0;
            while (l < r)
            {
                var leftHeight = height[l];
                var rightHeight = height[r];

                if (leftHeight == 0 || rightHeight == 0)
                {
                    if (rightHeight <= leftHeight)
                        r--;
                    else
                        l++;
                    continue;
                }

                var width = r - l;
                var currHeight = Math.Min(leftHeight, rightHeight);
                var area = width * currHeight;
                maxArea = Math.Max(maxArea, area);

                if (rightHeight <= leftHeight)
                    r--;
                else
                    l++;
            }
            return maxArea;
        }
        
        public static async Task Main(string[] args)
        {
            Console.WriteLine(MaxArea(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
            Console.WriteLine(MaxArea(new[] { 1, 1 }));
        }
    }
}