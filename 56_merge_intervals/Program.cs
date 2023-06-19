namespace _56_merge_intervals
{
    internal class Program
    {
        public static int[][] Merge(int[][] intervals)
        {
            var result = new List<int[]>();

            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            int[] curr = intervals[0];
            foreach(var interval in intervals)
            {
                if (interval[0] <= curr[1])
                    curr[1] = Math.Max(curr[1], interval[1]);
                else
                {
                    result.Add(curr);
                    curr = interval;
                }
            }
            result.Add(curr);

            return result.ToArray();
        }

        static void Main(string[] args)
        {
            var intervals = new[]
            {
                new[] {1, 3},
                new[] {8, 10},
                new[] {2, 6},
                new[] {15, 18}
            };
            var result = Merge(intervals);
            foreach (var interval in result)
                Console.WriteLine($"[{interval[0]}, {interval[1]}]");

            intervals = new[]
            {
                new[] {1, 4},
                new[] {4, 5}
            };
            result = Merge(intervals);
            foreach (var interval in result)
                Console.WriteLine($"[{interval[0]}, {interval[1]}]");
            
            intervals = new[]
            {
                new[] {1, 4},
                new[] {2, 3}
            };
            result = Merge(intervals);
            foreach (var interval in result)
                Console.WriteLine($"[{interval[0]}, {interval[1]}]");
        }
    }
}