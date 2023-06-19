namespace _200_number_of_islands
{
    internal class Program
    {
        public static void VisitIsland(char[][] grid, int rows, int cols, int i, int j)
        {
            if (i < 0 || j < 0 || i == rows || j == cols)
                return;

            if (grid[i][j] == '0')
                return;

            grid[i][j] = '0';

            VisitIsland(grid, rows, cols, i, j + 1);
            VisitIsland(grid, rows, cols, i + 1, j);
            VisitIsland(grid, rows, cols, i, j - 1);
            VisitIsland(grid, rows, cols, i - 1, j);
        }

        public static int NumIslands(char[][] grid)
        {
            var rows = grid.Length;
            if (rows == 0)
                return 0;

            var cols = grid[0].Length;
            if (cols == 0)
                return 0;

            var result = 0;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (grid[i][j] == '1')
                    {
                        result++;
                        VisitIsland(grid, rows, cols, i, j + 1);
                        VisitIsland(grid, rows, cols, i + 1, j);
                        VisitIsland(grid, rows, cols, i, j - 1);
                        VisitIsland(grid, rows, cols, i - 1, j);
                    }

            return result;
        }

        static void Main(string[] args)
        {
            var grid = new[]{
                new[] { '1', '1', '1', '1', '0' },
                new[] { '1', '1', '0', '1', '0' },
                new[] { '1', '1', '0', '0', '0' },
                new[] { '0', '0', '0', '0', '0' }
                };
            Console.WriteLine(NumIslands(grid));

            grid = new[]{
                new[] { '1', '1', '0', '0', '0' },
                new[] { '1', '1', '0', '0', '0' },
                new[] { '0', '0', '1', '0', '0' },
                new[] { '0', '0', '0', '1', '1' }
                };
            Console.WriteLine(NumIslands(grid));
        }
    }
}