namespace _113_path_sum_2
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

        public static void Traverse(TreeNode root, int targetSum, IList<IList<int>> result)
        {
            if (root == null)
                return;

            var stack = new Stack<(TreeNode node, int sum, int ix)>();
            stack.Push((root, root.val, 0));
            var candidate = new List<int>();
            candidate.Add(root.val);
            while (stack.Count > 0)
            {
                var curr = stack.Pop();
                if (curr.ix < candidate.Count)
                    candidate[curr.ix] = curr.node.val;
                else
                    candidate.Add(curr.node.val);

                if (curr.node.left == null && curr.node.right == null && curr.sum == targetSum)
                    result.Add(candidate.GetRange(0, curr.ix + 1));

                if (curr.node.left != null)
                    stack.Push((curr.node.left, curr.sum + curr.node.left.val, curr.ix + 1));

                if (curr.node.right != null)
                    stack.Push((curr.node.right, curr.sum + curr.node.right.val, curr.ix + 1));
            }
        }

        public static void Traverse2(TreeNode root, int targetSum, IList<IList<int>> result, List<int> path)
        {
            if (root == null)
                return;

            path.Add(root.val);

            var diff = targetSum - root.val;
            var isLeaf = root.left == null && root.right == null;

            if (isLeaf && diff == 0)
                result.Add(path.ToArray());

            Traverse2(root.left, diff, result, path);
            Traverse2(root.right, diff, result, path);

            path.RemoveAt(path.Count - 1);
        }


        public static IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            var result = new List<IList<int>>();

            //Traverse(root, targetSum, result);
            Traverse2(root, targetSum, result, new List<int>());

            return result;
        }

        static void Main(string[] args)
        {
            var tree = new TreeNode(5);

            tree.left = new TreeNode(4);
            tree.left.left = new TreeNode(11);
            tree.left.left.left = new TreeNode(7);
            tree.left.left.right = new TreeNode(2);

            tree.right = new TreeNode(8);
            tree.right.left = new TreeNode(13);
            tree.right.right = new TreeNode(4);
            tree.right.right.left = new TreeNode(5);
            tree.right.right.right = new TreeNode(1);

            var result = PathSum(tree, 22);

            foreach (var list in result)
            {
                foreach (var i in list)
                {
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }

        }
    }
}