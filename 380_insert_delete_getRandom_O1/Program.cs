namespace _380_insert_delete_getRandom_O1
{
    internal class Program
    {
        public class RandomizedSetDL
        {

            private readonly Dictionary<int, int> valToIx = new Dictionary<int, int>();
            private readonly List<int> list = new List<int>();

            public RandomizedSetDL()
            {

            }

            public bool Insert(int val)
            {
                if (valToIx.TryAdd(val, list.Count))
                {
                    list.Add(val);
                    return true;
                }

                return false;
            }

            public bool Remove(int val)
            {
                if (!valToIx.ContainsKey(val))
                    return false;

                var ixToRemove = valToIx[val];
                var lastVal = list[ixToRemove] = list[list.Count - 1];
                valToIx[lastVal] = ixToRemove;

                list.RemoveAt(list.Count - 1);
                valToIx.Remove(val);

                return true;
            }

            public int GetRandom()
            {
                return list[Random.Shared.Next(0, list.Count)];
            }
        }

        public class RandomizedSetDD
        {

            private readonly Dictionary<int, int> valToIx = new Dictionary<int, int>();
            private readonly Dictionary<int, int> ixToVal = new Dictionary<int, int>();
            private int Count = 0;
            public RandomizedSetDD()
            {

            }

            public bool Insert(int val)
            {
                if (valToIx.TryAdd(val, Count))
                {
                    ixToVal[Count] = val;
                    Count++;
                    return true;
                }

                return false;
            }

            public bool Remove(int val)
            {
                if (!valToIx.ContainsKey(val))
                    return false;

                var ixToRemove = valToIx[val];
                var lastVal = ixToVal[ixToRemove] = ixToVal[Count - 1];
                valToIx[lastVal] = ixToRemove;

                ixToVal.Remove(Count - 1);
                valToIx.Remove(val);
                Count--;

                return true;
            }

            public int GetRandom()
            {
                return ixToVal[Random.Shared.Next(0, Count)];
            }
        }

        static void Main(string[] args)
        {
            var set = new RandomizedSetDL();
            Console.WriteLine(set.Insert(1));
            Console.WriteLine(set.Remove(2));
            Console.WriteLine(set.Insert(2));
            Console.WriteLine(set.GetRandom());
            Console.WriteLine(set.Remove(1));
            Console.WriteLine(set.Insert(2));
            Console.WriteLine(set.GetRandom());
        }
    }
}