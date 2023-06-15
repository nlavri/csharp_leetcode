namespace _74_search_2d_matrix
{
    internal class Program
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int rl = 0;
            int rh = matrix.Length - 1;

            while (rl <= rh && rh > 0)
            {
                var rMid = (rh + rl) / 2;
                var row0 = matrix[rMid][0];
                if (row0 == target)
                    return true;
                else if (target < row0)
                    rh = rMid - 1;
                else
                    rl = rMid + 1;
            }
            int targetRow = Math.Max(0, rl >= rh ? rh : rl);
            int cl = 0;
            int ch = matrix[targetRow].Length - 1;

            while (cl <= ch)
            {
                var cMid = (ch + cl) / 2;
                var val = matrix[targetRow][cMid];
                if (val == target)
                    return true;
                else if (target < val)
                    ch = cMid - 1;
                else
                    cl = cMid + 1;
            }

            return false;
        }
        
        public static bool SearchMatrix(int[,] matrix, int target)
        {
            int rl = 0;
            int rh = matrix.GetUpperBound(0);

            while (rl <= rh && rh > 0)
            {
                var rMid = (rh + rl) / 2;
                var row0 = matrix[rMid,0];
                if (row0 == target)
                    return true;
                else if (target < row0)
                    rh = rMid - 1;
                else
                    rl = rMid + 1;
            }
            int targetRow = Math.Max(0, rl >= rh ? rh : rl);
            int cl = 0;
            int ch = matrix.GetUpperBound(1);

            while (cl <= ch)
            {
                var cMid = (ch + cl) / 2;
                var val = matrix[targetRow,cMid];
                if (val == target)
                    return true;
                else if (target < val)
                    ch = cMid - 1;
                else
                    cl = cMid + 1;
            }

            return false;
        }

        static void Main(string[] args)
        {
            //[[1,3,5,7],[10,11,16,20],[23,30,34,60]]
            var matrix = new int[,] { { 1, 3, 5, 7 },  { 10, 11, 16, 20 },  { 23, 30, 34, 60 } };
            Console.WriteLine(SearchMatrix(matrix, 3));
            Console.WriteLine(SearchMatrix(matrix, 200));
            Console.WriteLine(SearchMatrix(matrix, 11));
            Console.WriteLine(SearchMatrix(new int[,] { { 1 } }, 0));
            Console.WriteLine(SearchMatrix(new int[,] { { 1 }, { 3 } }, 0));
        }
    }
}