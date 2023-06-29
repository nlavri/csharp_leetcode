namespace _356_line_reflection
{
    internal class Program
    {
        public static bool IsReflectedSlow(int[][] points)
        {
            if (points.Length == 1)
                return true;

            var found = new bool[points.Length];
            var mL = points.MinBy(x => x[0]);
            var mR = points.MaxBy(x => x[0]);
            var sA = mL[0] + (mR[0] - mL[0]) / 2D;

            for (int i = 0; i < points.Length; i++)
            {
                var p1 = points[i];
                if (p1[0] == sA)
                    found[i] = true;
                else
                    for (int j = i + 1; j < points.Length; j++)
                    {
                        if (found[i] && found[j])
                            continue;
                        var p2 = points[j];
                        if (p1[1] == p2[1] && (p1[0] + (p2[0] - p1[0]) / 2D) == sA)
                            found[i] = found[j] = true;
                    }
            }

            return found.All(x => x);
        }

        public static bool IsReflected(int[][] points)
        {
            if (points.Length == 1)
                return true;

            var set = new HashSet<(int x, int y)>();
            var mL = points.MinBy(x => x[0]);
            var mR = points.MaxBy(x => x[0]);
            var sX = mL[0] + (mR[0] - mL[0]) / 2D;

            foreach (var p in points)
                set.Add((p[0], p[1]));

            foreach (var p in points)
            {
                var xToFind = (int)(sX + (sX - p[0]));
                if (!set.Contains((xToFind, p[1])))
                    return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            //[[0,0],[0,-1]] true
            //[[-16,1],[-16,1],[-15,1],[-15,1]] true
            //[[1,1],[-1,-1]] - false

            Console.WriteLine(IsReflectedSlow(new[]
            {
                new[] {0, 0},
                new[] {0, -1}
            }));

            Console.WriteLine(IsReflectedSlow(new[]
            {
                new[] {-16, 1},
                new[] {-16, 1},
                new[] {-15, 1},
                new[] {-15, 1}
            }));

            Console.WriteLine(IsReflectedSlow(new[]
            {
                new[] {1, 1},
                new[] {-1, -1}
            }));
            
            Console.WriteLine(IsReflected(new[]
            {
                new[] {0, 0},
                new[] {0, -1}
            }));

            Console.WriteLine(IsReflected(new[]
            {
                new[] {-16, 1},
                new[] {-16, 1},
                new[] {-15, 1},
                new[] {-15, 1}
            }));

            Console.WriteLine(IsReflected(new[]
            {
                new[] {1, 1},
                new[] {-1, -1}
            }));
        }
    }
}