namespace _42_trapping_rain_water
{
    internal class Program
    {
        public static int TrapSlow(int[] height)
        {
            int ans = 0;
            for (int i = 1; i < height.Length - 1; i++)
            {
                int left_max = 0, right_max = 0;
                
                for (int j = i; j >= 0; j--)
                    left_max = Math.Max(left_max, height[j]);
                
                for (int j = i; j < height.Length; j++)
                    right_max = Math.Max(right_max, height[j]);
                ans += Math.Min(left_max, right_max) - height[i];
            }
            return ans;
        }

        public static int Trap(int[] height)
        {
            int ans = 0;
            //if(ans.Length == 0 || ans.Length ==)
            var left_max = new int[height.Length];
            var right_max = new int[height.Length];

            left_max[0] = height[0];
            for (int i = 1; i < height.Length; i++)
                left_max[i] = Math.Max(height[i], left_max[i - 1]);

            right_max[height.Length - 1] = height[height.Length - 1];
            for (int i = height.Length - 2; i > 0; i--)
                right_max[i] = Math.Max(height[i], right_max[i + 1]);

            for (int i = 1; i < height.Length - 1; i++)
                ans += Math.Min(left_max[i], right_max[i]) - height[i];

            return ans;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
            Console.WriteLine(Trap(new int[] { 4, 2, 0, 3, 2, 5 }));
        }
    }
}