namespace _150_evaluate_reverse_polish_notation
{
    internal class Program
    {
        public static int EvalRPN(string[] tokens)
        {
            var stack = new Stack<int>();

            foreach (var t in tokens)
            {
                switch (t)
                {
                    case "+":
                        var rhs = stack.Pop();
                        var lhs = stack.Pop();
                        stack.Push(lhs + rhs);
                        break;
                    case "-":
                        rhs = stack.Pop();
                        lhs = stack.Pop();
                        stack.Push(lhs - rhs);
                        break;
                    case "/":
                        rhs = stack.Pop();
                        lhs = stack.Pop();
                        stack.Push(lhs / rhs);
                        break;
                    case "*":
                        rhs = stack.Pop();
                        lhs = stack.Pop();
                        stack.Push(lhs * rhs);
                        break;
                    default:
                        stack.Push(int.Parse(t));
                        break;
                }
            }

            return stack.Pop();
        }



        static void Main(string[] args)
        {
            Console.WriteLine(EvalRPN(new[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }));//22
        }
    }
}