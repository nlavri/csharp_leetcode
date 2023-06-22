namespace trees
{
    internal class Program
    {
        class Node
        {
            public int Value { get; set; }

            public Node? Left { get; set; }

            public Node? Right { get; set; }

            public Node(int val)
            {
                Value = val;
            }
        }

        static void StackTraversal(Node root)
        {
            var stack = new Stack<Node>();

            var current = root;
            while (current != null || stack.Count > 0)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();
                    Console.Write(current.Value + " ");
                    current = current.Right;
                }
            }
        }

        static void QueueTraversal(Node root)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.Write(current.Value + " ");

                if (current.Left != null)
                    queue.Enqueue(current.Left);

                if (current.Right != null)
                    queue.Enqueue(current.Right);

            }
        }

        static void DfsInorder(Node? root)
        {
            if (root == null)
                return;

            DfsInorder(root.Left);
            Console.Write(root.Value + " ");
            DfsInorder(root.Right);
        }

        static int TreeHeight(Node? root)
        {
            if (root == null)
                return 0;

            var lH = TreeHeight(root.Left);
            var rH = TreeHeight(root.Right);

            return Math.Max(lH, rH) + 1;
        }


        static void PrintTreeLevel(Node? root, int level)
        {
            if (root == null)
                return;

            if (level == 0)
                Console.Write(root.Value + " ");

            if (root.Left != null)
                PrintTreeLevel(root.Left, level - 1);

            if (root.Right != null)
                PrintTreeLevel(root.Right, level - 1);
        }

        static void BfsInorder(Node? root)
        {
            var height = TreeHeight(root);
            for (int i = 0; i < height; i++)
                PrintTreeLevel(root, i);
        }

        static void Main(string[] args)
        {
            //      1
            //     / \
            //    2   3
            //   / \   \
            //  4   5   6
            var root = new Node(1);
            root.Left = new Node(2);
            root.Left.Left = new Node(4);
            root.Left.Right = new Node(5);
            root.Right = new Node(3);
            root.Right.Right = new Node(6);
            StackTraversal(root);
            Console.WriteLine("\r\n____________________");
            DfsInorder(root);
            Console.WriteLine("\r\n____________________");
            Console.WriteLine(TreeHeight(root));
            Console.WriteLine("\r\n____________________");
            BfsInorder(root);
            Console.WriteLine("\r\n____________________");
            QueueTraversal(root);

            var s = new HashSet<Node>();
            s.Add(root);
            s.Add(root);
        }
    }
}