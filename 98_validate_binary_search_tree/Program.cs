namespace _98_validate_binary_search_tree
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

        static bool IsValid(TreeNode node, int? l, int? h)
        {
            if (node == null)
                return true;

            if ((l.HasValue && node.val <= l) || (h.HasValue && node.val >= h))
                return false;

            return IsValid(node.left, l, node.val) && IsValid(node.right, node.val, h);
        }

        
        static bool IsValid2(TreeNode node, ref TreeNode prev)
        {
            if (node == null)
                return true;

            if (!IsValid2(node.left, ref prev))
                return false;

            if (node.val <= prev?.val)
                return false;

            prev = node;

            return IsValid2(node.right, ref prev);
        }

        static void Main(string[] args)
        {
            var tree = new TreeNode(3);

            tree.left = new TreeNode(1);
            tree.left.left = new TreeNode(0);
            tree.left.right = new TreeNode(2);

            tree.right = new TreeNode(5);
            tree.right.left = new TreeNode(4);
            tree.right.right = new TreeNode(6);

            Console.WriteLine(IsValid(tree, null, null));

            TreeNode prev = null;
            Console.WriteLine(IsValid2(tree, ref prev));


        }
    }
}