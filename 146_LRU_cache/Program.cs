using System.Collections.Generic;
using System.ComponentModel;

namespace _146_LRU_cache
{
    internal class Program
    {
        public class LRUCache
        {

            private readonly Dictionary<int, LinkedListNode<(int Key, int Value)>> cache;
            private readonly LinkedList<(int Key, int Value)> lru;
            private readonly int capacity;
            public LRUCache(int capacity)
            {
                this.cache = new Dictionary<int, LinkedListNode<(int, int)>>(capacity);
                this.lru = new LinkedList<(int, int)>();
                this.capacity = capacity;
            }

            public int Get(int key)
            {
                var entry = cache.GetValueOrDefault(key);
                if (entry == null)
                    return -1;

                lru.Remove(entry);
                lru.AddFirst(entry);

                return entry.Value.Value;
            }

            public void Put(int key, int value)
            {
                var entry = cache.GetValueOrDefault(key);
                if (entry != null)
                {
                    lru.Remove(entry);
                }

                cache[key] = lru.AddFirst((key, value));

                if (cache.Count > this.capacity)
                {
                    cache.Remove(lru.Last.Value.Key);
                    lru.RemoveLast();
                }
            }
        }


        static void Main(string[] args)
        {
            var cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Console.WriteLine(cache.Get(1));
            cache.Put(3, 3);
            Console.WriteLine(cache.Get(2));
            cache.Put(4, 4);
            Console.WriteLine(cache.Get(1));
            Console.WriteLine(cache.Get(3));
            Console.WriteLine(cache.Get(4));
            
        }
    }
}