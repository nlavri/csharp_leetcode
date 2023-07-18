namespace union_find
{
    public class DisjointSetUnion
    {
        private int[] parent;
        private int[] size;

        public DisjointSetUnion(int size)
        {
            this.parent = new int[size + 1];
            this.size = new int[size + 1];
            for (int i = 0; i < size + 1; ++i)
            {
                this.parent[i] = i;
                this.size[i] = 1;
            }
        }

        /** return the component id that the element x belongs to. */
        public int find(int x)
        {
            if (this.parent[x] != x)
                this.parent[x] = this.find(this.parent[x]);
            return this.parent[x];
        }

        /**
         * merge the two components that x, y belongs to respectively,
         * and return the merged component id as the result.
         */
        public int union(int x, int y)
        {
            int px = this.find(x);
            int py = this.find(y);

            // the two nodes share the same group
            if (px == py)
                return px;

            // otherwise, connect the two sets (components)
            if (this.size[px] > this.size[py])
            {
                // add the node to the union with less members.
                // keeping px as the index of the smaller component
                int temp = px;
                px = py;
                py = temp;
            }

            // add the smaller component to the larger one
            this.parent[px] = py;
            this.size[py] += this.size[px];
            return py;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var u = new DisjointSetUnion(5);
            Console.WriteLine(u.find(1));
            Console.WriteLine(u.find(2));
            Console.WriteLine(u.find(3));
            Console.WriteLine(u.find(4));
            Console.WriteLine(u.find(5));

            Console.WriteLine(u.union(5, 1));
            Console.WriteLine(u.union(3, 1));
            Console.WriteLine(u.find(1));
            Console.WriteLine(u.find(5));
            Console.WriteLine(u.find(3));
        }
    }
}