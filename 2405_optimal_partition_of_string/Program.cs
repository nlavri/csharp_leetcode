using System.ComponentModel.DataAnnotations;

namespace _2405_optimal_partition_of_string
{
    internal class Program
    {
        public static int PartitionString(string s)
        {
            var result = 0;
            //var set = new HashSet<char>();
            var set = new byte['z' - 'a' + 1];

            foreach (var c in s)
            {
                var ix = c - 'a';
                if (set[ix] != 0)
                {
                    result++;
                    for (int i = 0; i < set.Length; i++)
                        set[i] = 0;
                }
                set[ix] = 1;
            }

            return result + 1;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(PartitionString("abacaba"));
            Console.WriteLine(PartitionString("ssssss"));
        }
    }
}