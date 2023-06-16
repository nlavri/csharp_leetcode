namespace _104_maximum_depth_of_binary_tree
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

        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            var lh = MaxDepth(root.left);
            var rh = MaxDepth(root.right);

            return Math.Max(lh, rh) + 1;
        }

        static void Main(string[] args)
        {
            var tree = new TreeNode(3);
            tree.left = new TreeNode(9);
            tree.right = new TreeNode(20);
            tree.right.left = new TreeNode(15);
            tree.right.right = new TreeNode(5);

            Console.WriteLine(MaxDepth(tree));
        }
    }
}