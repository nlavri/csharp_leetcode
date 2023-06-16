namespace _20_valid_parentheses
{
    internal class Program
    {
        public static bool IsValid(string s)
        {
            if (s.Length == 1)
                return false;

            var stack = new Stack<char>();

            foreach (var c in s)
            {
                if (stack.Count > 0)
                {
                    var peek = stack.Peek();
                    if ((peek == '{' && c == '}') ||
                        (peek == '(' && c == ')') ||
                        (peek == '[' && c == ']'))
                    {
                        stack.Pop();
                    }
                    else
                        stack.Push(c);
                }
                else
                    stack.Push(c);
            }

            return stack.Count == 0;
        }
        
        public static bool IsValid2(string s)
        {
            if (s.Length == 1)
                return false;

            var stack = new Stack<char>();

            foreach (var c in s)
            {
                if (c == '{' || c == '(' || c == '[')
                    stack.Push(c);
                else
                {
                    if (stack.Count == 0)
                        return false;
                    var peek = stack.Peek();
                    if (c == '}' && peek != '{')
                        return false;
                    if (c == ')' && peek != '(')
                        return false;
                    if (c == ']' && peek != '[')
                        return false;
                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(IsValid("()[]{}"));
            Console.WriteLine(IsValid("({[)"));
            Console.WriteLine(IsValid2("()[]{}"));
            Console.WriteLine(IsValid2("({[)"));
        }
    }
}