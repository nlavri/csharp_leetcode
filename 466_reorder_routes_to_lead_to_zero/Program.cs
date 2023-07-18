namespace _466_reorder_routes_to_lead_to_zero
{
    internal class Program
    {
        public static void dfs(int node, int parent, Dictionary<int, List<List<int>>> adj, ref int count)
        {
            if (!adj.ContainsKey(node))
            {
                return;
            }
            foreach (var nei in adj[node])
            {
                int child = nei[0];
                int sign = nei[1];
                if (child != parent)
                {
                    count += sign;
                    dfs(child, node, adj, ref count);
                }
            }
        }

        public static int MinReorder(int n, int[][] connections)
        {
            var adj = new Dictionary<int, List<List<int>>>();
            foreach(int[] connection in connections)
            {
                adj[connection[0]] = adj.GetValueOrDefault(connection[0], new List<List<int>>());
                adj[connection[0]].Add(new List<int> { connection[1], 1 });
                adj[connection[1]] = adj.GetValueOrDefault(connection[1], new List<List<int>>());
                adj[connection[1]].Add(new List<int> { connection[0], 0 });
            }
            var count = 0;
            dfs(0, -1, adj, ref count);
            return count;
        }
        
        static void Main(string[] args)
        {
            //[[0,1],[1,3],[2,3],[4,0],[4,5]]
            Console.WriteLine(MinReorder(6, new[] { new[] { 0, 1 }, new[] { 1, 3 }, new[] { 2, 3 }, new[] { 4, 0 }, new[] { 4, 5 } }));
        }
    }
}