using System.Collections.Generic;

namespace _347_top_k_frequent_elements
{
    internal class Program
    {
        public static int[] TopKFrequent(int[] nums, int k)
        {
            var freq = new Dictionary<int, int>();
            foreach (var n in nums)
                freq[n] = freq.GetValueOrDefault(n) + 1;

            var heap = new PriorityQueue<int, int>();
            foreach (var kvp in freq)
                heap.Enqueue(kvp.Key, kvp.Value);

            while (heap.Count > k)
                heap.Dequeue();

            var result = new List<int>();

            while (heap.Count > 0)
                result.Add(heap.Dequeue());

            return result.Reverse<int>().ToArray();
        }

        static void Main(string[] args)
        {

            var nums = new[] { 1, 1, 1, 2, 2, 3 };
            //[1,2]
            foreach (var n in TopKFrequent(nums, 1))
                Console.Write(n);

            Console.WriteLine("\r\n----------------");

            //[1]
            nums = new[] { 1 };
            foreach (var n in TopKFrequent(nums, 1))
                Console.Write(n);

            Console.WriteLine("\r\n----------------");
        }
    }
}