using System;

namespace _1051_height_checker
{
    internal class Program
    {
        public static int HeightChecker(int[] heights)
        {
            var heighs_frequencies = new int[101];
            var result = 0;

            foreach (var h in heights)
                heighs_frequencies[h] += 1;

            var h_index = 0;
            for (int i = 0; i < heighs_frequencies.Length; i++)
                for (var j = 0; j < heighs_frequencies[i]; j++)
                {
                    if (heights[h_index] != i)
                        result += 1;
                    h_index += 1;
                }
            
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(HeightChecker(new[] { 1, 1, 4, 2, 1, 3 }));

            var s = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

            s.Enqueue(1, 1);
            s.Enqueue(2, 2);
            s.Enqueue(3, 3);

            Console.WriteLine(s.Peek());
        }
    }
}