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
        static void StackTraversal2(Node root)
        {
            var stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                
                Console.Write(current.Value + " ");

                if (current.Right != null)
                    stack.Push(current.Right);

                if (current.Left != null)
                    stack.Push(current.Left);
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

        static void DfsPreorder(Node? root)
        {
            if (root == null)
                return;

            Console.Write(root.Value + " ");
            DfsPreorder(root.Left);
            DfsPreorder(root.Right);
        }

        static void DfsInorder(Node? root)
        {
            if (root == null)
                return;

            DfsInorder(root.Left);
            Console.Write(root.Value + " ");
            DfsInorder(root.Right);
        }
        

        static void DfsPostorder(Node? root)
        {
            if (root == null)
                return;

            DfsPostorder(root.Left);
            DfsPostorder(root.Right);
            Console.Write(root.Value + " ");
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
            StackTraversal2(root);
            Console.WriteLine("\r\n____________________");
            
            Console.WriteLine("DfsPreorder");
            DfsPreorder(root);
            Console.WriteLine("\r\n____________________");

            Console.WriteLine("DfsInorder");
            DfsInorder(root);
            Console.WriteLine("\r\n____________________");

            Console.WriteLine("DfsPostorder");
            DfsPostorder(root);
            Console.WriteLine("\r\n____________________");

            Console.WriteLine(TreeHeight(root));
            Console.WriteLine("\r\n____________________");
            BfsInorder(root);
            Console.WriteLine("\r\n____________________");
            QueueTraversal(root);
        }
    }
}