namespace _680_valid_palindrome_2
{
    internal class Program
    {
        public static bool ValidPalindrome(string s)
        {
            if (s.Length == 1 || s.Length == 2)
                return true;

            for (int l = 0, r = s.Length - 1; l < r; l++, r--)
            {
                if (s[l] != s[r])
                    return IsPalindrome(s, l + 1, r) || IsPalindrome(s, l, r - 1);
            }
            return true;
        }

        static bool IsPalindrome(string s, int l, int r)
        {
            for (; l < r; l++, r--)
                if (s[l] != s[r])
                    return false;
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ValidPalindrome("aba"));
            Console.WriteLine(ValidPalindrome("abca"));
            Console.WriteLine(ValidPalindrome("abc"));
        }
    }
}