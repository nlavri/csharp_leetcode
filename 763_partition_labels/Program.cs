namespace _763_partition_labels
{
    internal class Program
    {
        public static IList<int> PartitionLabels(string s)
        {
            if (s.Length == 1)
                return new[] { 1 };

            var result = new List<int>();

            var set = new Dictionary<char, int>();
            foreach (var c in s)
                set[c] = s.LastIndexOf(c);

            int l = 0, r = set[s[0]], i = 0;
            while (i < s.Length)
            {
                var lChar = s[i];
                r = Math.Max(r, set[lChar]);

                if (i == r)
                {
                    result.Add(r - l + 1);
                    l = r + 1;
                }

                i++;
            }

            return result;
        }

        static void Main(string[] args)
        {
            var result = PartitionLabels("ababcbacadefegdehijhklij");
            foreach (var i in result)
                Console.Write(i + ",");

            Console.WriteLine("\r\n===============");

            result = PartitionLabels("eccbbbbdec");
            foreach (var i in result)
                Console.Write(i + ",");

            Console.WriteLine(Environment.NewLine + "===============");

            result = PartitionLabels("eccecbbbbd");
            foreach (var i in result)
                Console.Write(i + ",");
        }
    }
}