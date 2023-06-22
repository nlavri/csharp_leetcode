namespace _101_symmetric_tree
{
    internal class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        static bool Symmetry(TreeNode p, TreeNode q)
        {
            var queue = new Queue<(TreeNode, TreeNode)>();
            queue.Enqueue((p, q));
            while (queue.Count > 0)
            {
                var (pp, qq) = queue.Dequeue();
                
                if (pp == null && qq == null)
                    continue;
                
                if (pp?.val != qq?.val)
                    return false;

                queue.Enqueue((pp.left, qq.right));
                queue.Enqueue((pp.right, qq.left));
            }

            return true;
        }

        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return false;

            return Symmetry(root.left, root.right);
        }
        
        static void Main(string[] args)
        {
            var tree = new TreeNode(1);
            tree.left = new TreeNode(2);
            tree.right = new TreeNode(2);
            tree.left.left = new TreeNode(3);
            tree.left.right = new TreeNode(4);
            tree.right.left = new TreeNode(4);
            tree.right.right = new TreeNode(3);
            
            Console.WriteLine(IsSymmetric(tree));
            
            tree = new TreeNode(1);
            tree.left = new TreeNode(2);
            tree.right = new TreeNode(2);
            //tree.left.left = new TreeNode(3);
            tree.left.right = new TreeNode(4);
            //tree.right.left = new TreeNode(4);
            tree.right.right = new TreeNode(3);
            
            Console.WriteLine(IsSymmetric(tree));
        }
    }
}