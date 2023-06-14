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
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Right;
                }

                current = stack.Pop();
                Console.Write(current.Value + " ");
                current = current.Left;
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
            Console.WriteLine("____________________");
            QueueTraversal(root);

            var s = new HashSet<Node>();
            s.Add(root);
            s.Add(root);
        }
    }
}