namespace _443_string_compression
{
    internal class Program
    {
        public static int Compress(char[] chars)
        {
            if (chars.Length == 1)
                return 1;

            int newLen = 0;

            char c = chars[0];
            int charLen = 1;
            int i = 1;
            while (i <= chars.Length)
            {
                var end = i == chars.Length;
                var ci = end ? c : chars[i];
                if (ci != c || end)
                {
                    chars[newLen++] = c;
                    if (charLen > 1)
                    {
                        var charLenStr = charLen.ToString();
                        foreach (var cl in charLenStr)
                            chars[newLen++] = cl;
                    }
                    charLen = 0;
                    c = ci;
                }
                charLen++;
                i++;
            }

            return newLen;
        }
        
        static void Main(string[] args)
        {

            var chars = new char[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' };
            Console.WriteLine(Compress(chars));
            Console.WriteLine(string.Join(",", chars));

            chars = new char[] { 'a' };
            Console.WriteLine(Compress(chars));
            Console.WriteLine(string.Join(",", chars));

            chars = new char[] { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' };
            Console.WriteLine(Compress(chars));
            Console.WriteLine(string.Join(",", chars));

            chars = new char[] { 'a', 'a', 'a', 'b', 'b', 'a', 'a' };
            Console.WriteLine(Compress(chars));
            Console.WriteLine(string.Join(",", chars));

            chars = new char[] { 'a', 'a', 'a', 'a', 'a', 'b' };
            Console.WriteLine(Compress(chars));
            Console.WriteLine(string.Join(",", chars));

            chars = new char[] { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a' };
            Console.WriteLine(Compress(chars));
            Console.WriteLine(string.Join(",", chars));

            chars = new char[] { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'b' };
            Console.WriteLine(Compress(chars));
            Console.WriteLine(string.Join(",", chars));

            chars = new char[] { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'b', 'b' };
            Console.WriteLine(Compress(chars));
            Console.WriteLine(string.Join(",", chars));

            chars = new char[] { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'b', 'b', 'b' };
            Console.WriteLine(Compress(chars));
            Console.WriteLine(string.Join(",", chars));

            chars = new char[] { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'b', 'b', 'b', 'c', 'c', 'c' };
            Console.WriteLine(Compress(chars));
            Console.WriteLine(string.Join(",", chars));
        }
    }
}