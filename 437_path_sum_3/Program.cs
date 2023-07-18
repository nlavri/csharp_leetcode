namespace _437_path_sum_3
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

        static void Traverse(TreeNode node, int targetSum, long currSum, Dictionary<long, int> dict, ref int result)
        {
            currSum += node.val;

            if (currSum == targetSum)
                result++;

            result += dict.GetValueOrDefault(currSum - targetSum);

            dict[currSum] = dict.GetValueOrDefault(currSum) + 1;

            if (node.left != null)
                Traverse(node.left, targetSum, currSum, dict, ref result);

            if (node.right != null)
                Traverse(node.right, targetSum, currSum, dict, ref result);

            dict[currSum] = dict.GetValueOrDefault(currSum) - 1;
        }

        public static int PathSum(TreeNode root, int targetSum)
        {
            if (root == null)
                return 0;

            int result = 0;
            var dict = new Dictionary<long, int>();
            Traverse(root, targetSum, 0, dict, ref result);

            return result;
        }

        static void Main(string[] args)
        {
            var tree = new TreeNode(10);

            tree.left = new TreeNode(5);
            tree.left.left = new TreeNode(3);
            tree.left.left.left = new TreeNode(3);
            tree.left.left.right = new TreeNode(-2);
            tree.left.right = new TreeNode(2);
            tree.left.right.right = new TreeNode(1);

            tree.right = new TreeNode(-3);
            tree.right.right = new TreeNode(11);

            Console.WriteLine(PathSum(tree, 8));//3

            tree = new TreeNode(0);

            tree.left = new TreeNode(1);

            tree.right = new TreeNode(1);

            Console.WriteLine(PathSum(tree, 1));//4
        }
    }
}