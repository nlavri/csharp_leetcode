namespace _100_same_tree
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
        
        static bool Traverse(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if ((p != null && q == null) || (p == null && q != null))
                return false;
            if (p.val != q.val)
                return false;
            var leftResult = Traverse(p.left, q.left);
            var rightResult = Traverse(p.right, q.right);
            return leftResult && rightResult;
        }

        static bool CheckNodes(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            return p.val == q.val;
        }

        static bool Traverse2(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            if (p.val != q.val)
                return false;

            var stack = new Stack<(TreeNode, TreeNode)>();
            stack.Push((p, q));

            while (stack.Count > 0)
            {
                var (pN, qN) = stack.Pop();
                if (!CheckNodes(pN, qN))
                    return false;

                if (pN == null || qN == null)
                    continue;
                
                stack.Push((pN.left, qN.left));

                stack.Push((pN.right, qN.right));
            }

            return true;
        }

        static public bool IsSameTree(TreeNode p, TreeNode q)
        {
            return Traverse2(p, q);
        }
        
        static void Main(string[] args)
        {
            var p = new TreeNode(1);
            var q = new TreeNode(1);
            q.right = new TreeNode(20);


            Console.WriteLine(IsSameTree(p, q));
        }
    }
}