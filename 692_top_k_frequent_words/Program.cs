namespace _692_top_k_frequent_words
{
    internal class Program
    {
        public class WordComparer : IComparer<(string, int)>
        {
            public int Compare((string, int) x, (string, int) y)
            {
                return x.Item2 == y.Item2 ? string.Compare(x.Item1, y.Item1, StringComparison.OrdinalIgnoreCase) : y.Item2 - x.Item2;
            }
        }

        public static IList<string> TopKFrequent(string[] words, int k)
        {
            var freq = new Dictionary<string, int>();

            foreach (var word in words)
                freq[word] = freq.GetValueOrDefault(word) + 1;

            var heap = new PriorityQueue<string, (string, int)>(new WordComparer());

            foreach (var kvp in freq)
                heap.Enqueue(kvp.Key, (kvp.Key, kvp.Value));

            var result = new List<string>();

            int i = 0;
            while (i++ < k)
                result.Add(heap.Dequeue());

            return result;
        }
        
        public static IList<string> TopKFrequent2(string[] words, int k)
        {
            var freq = new Dictionary<string, int>();

            foreach (var word in words)
                freq[word] = freq.GetValueOrDefault(word) + 1;

            return freq
                .Select(x => (x.Value, x.Key))
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Take(k)
                .Select(x => x.Key).ToList();
        }

        static void Main(string[] args)
        {
            var words = TopKFrequent(new[] { "i", "love", "leetcode", "i", "love", "coding" }, 2);
            foreach (var word in words)
                Console.Write(word + ",");
            Console.WriteLine("\r\n----------------");

            words = TopKFrequent(new[] { "i", "love", "leetcode", "i", "love", "coding" }, 1);
            foreach (var word in words)
                Console.Write(word + ",");
            Console.WriteLine("\r\n----------------");

            words = TopKFrequent(new[] { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" }, 4);
            foreach (var word in words)
                Console.Write(word + ",");
            
            Console.WriteLine("\r\n============================");

            words = TopKFrequent2(new[] { "i", "love", "leetcode", "i", "love", "coding" }, 2);
            foreach (var word in words)
                Console.Write(word + ",");
            Console.WriteLine("\r\n----------------");

            words = TopKFrequent2(new[] { "i", "love", "leetcode", "i", "love", "coding" }, 1);
            foreach (var word in words)
                Console.Write(word + ",");
            Console.WriteLine("\r\n----------------");

            words = TopKFrequent2(new[] { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" }, 4);
            foreach (var word in words)
                Console.Write(word + ",");

            Console.WriteLine("\r\n============================");
        }
    }
}