namespace heap
{
    internal class Program
    {
        public class MinHeap
        {
            private int[] array;

            private int lastIndex = -1;

            public MinHeap(int initCapacity = 8)
            {
                this.array = new int[initCapacity];
            }

            public void Add(int val)
            {
                lastIndex++;

                if (lastIndex == array.Length)
                    Array.Resize(ref array, array.Length * 2);

                array[lastIndex] = val;

                Heapify();
            }

            private void Heapify()
            {
                int i = lastIndex;
                while (i > 0)
                {
                    var pI = (i - 1) / 2;
                    if (array[i] >= array[pI])
                        break;

                    (array[i], array[pI]) = (array[pI], array[i]);
                    i = pI;
                }
            }

            public int ExtractMin()
            {
                var result = Peek();

                array[0] = array[lastIndex];

                //for debug clarity
                array[lastIndex] = 0;

                lastIndex--;

                int i = 0;
                while (i < lastIndex)
                {
                    var lcI = 2 * i + 1;
                    var rcI = 2 * i + 2;

                    int val = array[i];
                    int? lcV = lcI < lastIndex ? array[lcI] : null;
                    int? rcV = rcI < lastIndex ? array[rcI] : null;

                    if (lcI < lastIndex && lcV < val && (!rcV.HasValue || lcV < rcV))
                    {
                        array[i] = lcV.Value;
                        array[lcI] = val;
                        i = lcI;
                    }
                    else if (rcV.HasValue && rcV < val)
                    {
                        array[i] = rcV.Value;
                        array[rcI] = val;
                        i = rcI;
                    }
                    else
                        break;
                }

                return result;
            }

            public int Peek()
            {
                if (lastIndex >= 0)
                    return array[0];

                throw new InvalidOperationException("Nothing to peek");
            }

        }
        static void Main(string[] args)
        {
            var heap = new MinHeap(4);
            heap.Add(1);
            Console.WriteLine(heap.Peek());
            heap.Add(2);
            Console.WriteLine(heap.Peek());
            heap.Add(3);
            Console.WriteLine(heap.Peek());
            heap.Add(4);
            Console.WriteLine(heap.Peek());
            heap.Add(5);
            Console.WriteLine(heap.Peek());
            heap.Add(6);
            Console.WriteLine(heap.Peek());
            heap.Add(0);
            Console.WriteLine(heap.Peek());
            heap.Add(0);
            Console.WriteLine(heap.Peek());
            heap.Add(-1);
            Console.WriteLine(heap.Peek());

            heap = new MinHeap(4);
            heap.Add(2);
            heap.Add(5);
            heap.Add(6);
            heap.Add(7);
            heap.Add(8);
            heap.Add(9);
            heap.Add(10);
            Console.WriteLine("Peek " + heap.Peek());
            Console.WriteLine("ExtractMin " + heap.ExtractMin());
            Console.WriteLine("Peek " + heap.Peek());
            Console.WriteLine("ExtractMin " + heap.ExtractMin());
            Console.WriteLine("Peek " + heap.Peek());
            Console.WriteLine("ExtractMin " + heap.ExtractMin());
            Console.WriteLine("Peek " + heap.Peek());
            Console.WriteLine("ExtractMin " + heap.ExtractMin());
            Console.WriteLine("Peek " + heap.Peek());
            Console.WriteLine("ExtractMin " + heap.ExtractMin());
            Console.WriteLine("Peek " + heap.Peek());
        }
    }
}