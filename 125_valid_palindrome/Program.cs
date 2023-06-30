using System.Text;

namespace _125_valid_palindrome
{
    internal class Program
    {
        public static bool IsPalindrome2(string s)
        {
            if (s.Length == 1)
                return true;
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                if (char.IsDigit(c))
                    sb.Append(c);
                else if (char.IsLetter(c))
                    sb.Append(char.ToLowerInvariant(c));
            }
            var str = sb.ToString();
            var arr1 = str.ToCharArray();
            Array.Reverse(arr1);
            var str1 = new string(arr1);

            return str == str1;
        }

        static bool IsPalindromeInternal(string s, int l, int r)
        {
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
            }
            return l == -1 && r == s.Length;
        }

        public static bool IsPalindrome(string s)
        {
            if (s.Length == 1)
                return true;
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                if (char.IsDigit(c))
                    sb.Append(c);
                else if (char.IsLetter(c))
                    sb.Append(char.ToLowerInvariant(c));
            }
            var str = sb.ToString();

            var isOdd = str.Length % 2 == 1;
            var halfLen = str.Length / 2;
            return isOdd ? IsPalindromeInternal(str, halfLen, halfLen) : IsPalindromeInternal(str, halfLen - 1, halfLen);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(IsPalindrome("abcba"));
            Console.WriteLine(IsPalindrome("race a car"));
            Console.WriteLine(IsPalindrome("A man, a plan, a canal: Panama"));
            Console.WriteLine(IsPalindrome2("A man, a plan, a canal: Panama"));
            Console.WriteLine(IsPalindrome2("race a car"));
            Console.WriteLine(IsPalindrome("abcba"));
        }
    }
}