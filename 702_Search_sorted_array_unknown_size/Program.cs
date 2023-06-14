namespace _702_Search_sorted_array_unknown_size
{
    internal class Program
    {
        public class ArrayReader
        {
            private readonly int[] arr;

            public ArrayReader(int[] arr)
            {
                this.arr = arr;
            }
            public int Get(int index)
            {
                return index >= 0 && index < arr.Length ? arr[index] : int.MaxValue;
            }
        }

        public static int Search(ArrayReader reader, int target)
        {
            var l = 0;
            var r = 10000 - 1;
            while (l <= r)
            {
                var mid = (l + r) / 2;
                var midValue = reader.Get(mid);
                if (midValue == target)
                    return mid;
                if (midValue == int.MaxValue)
                    r = mid - 1;
                else
                    l = mid + 1;

                Console.WriteLine($"{target} - #");
            }

            l = 0;
            r = r + 1;
            while (l <= r)
            {
                var mid = (l + r) / 2;
                var midVal = reader.Get(mid);
                if (midVal == target)
                    return mid;
                else if (midVal < target)
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            return -1;
        }
        
        public static int Search2(ArrayReader reader, int target)
        {
            if (reader.Get(0) == target)
                return 0;
            
            var l = 0;
            var r = 1;
            while (reader.Get(r) < target)
            {
                l = r;
                r *= 2;
                Console.WriteLine($"{target} - $");
            }
            
            while (l <= r)
            {
                var mid = (l + r) / 2;
                var midValue = reader.Get(mid);
                if (midValue == target)
                    return mid;
                if (midValue > target)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return -1;
        }

        static void Main(string[] args)
        {
            //4
            Console.WriteLine(Search(new ArrayReader(new int[] { -1, 0, 3, 5, 9, 12 }), 9));

            //-1
            Console.WriteLine(Search(new ArrayReader(new int[] { -1, 0, 3, 5, 9, 12 }), 2));

            //0
            Console.WriteLine(Search(new ArrayReader(new int[] { 5 }), 5));
            
            //4
            Console.WriteLine(Search2(new ArrayReader(new int[] { -1, 0, 3, 5, 9, 12 }), 9));

            //-1
            Console.WriteLine(Search2(new ArrayReader(new int[] { -1, 0, 3, 5, 9, 12 }), 2));

            //0
            Console.WriteLine(Search2(new ArrayReader(new int[] { 5 }), 5));
        }
    }
}