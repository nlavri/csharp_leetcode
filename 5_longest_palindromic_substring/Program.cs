namespace _5_longest_palindromic_substring
{
    internal class Program
    {
        static bool IsPalindrom(string s)
        {
            return s.SequenceEqual(s.ToCharArray().Reverse());
        }

        public static string LongestPalindrome2(string s)
        {
            if (1 == s.Length)
                return s;

            var best = string.Empty;
            var lastPalindrome = 0;
            var l = 0;
            var r = 2;
            for (int i = 0; i < s.Length - 1; i++)
            {
                for (int j = i + 1; j <= s.Length; j++)
                {
                    var cand = s[i..j];

                    if (IsPalindrom(cand) && cand.Length > best.Length)
                    {
                        best = cand;
                        lastPalindrome = i + j;
                    }
                }
            }

            return best;
        }

        public static int TryExpand(int l, int r, string s)
        {
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
            }
            return r - l - 1;
        }

        public static string LongestPalindrome(string s)
        {
            var l = 0;
            var r = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var oddLen = TryExpand(i, i, s);
                if (oddLen > r - l + 1)
                {
                    var halfLen = oddLen / 2;
                    l = i - halfLen;
                    r = i + halfLen;
                }

                var evenLen = TryExpand(i, i + 1, s);
                if (evenLen > r - l + 1)
                {
                    var halfLen = evenLen / 2;
                    l = i - halfLen + 1;
                    r = i + halfLen;
                }
            }

            return s[l..(r + 1)];
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(LongestPalindrome("babad"));
            Console.WriteLine(LongestPalindrome("cbbd"));
        }
    }
}