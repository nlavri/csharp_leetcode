namespace _424_longest_repeating_character_replacement
{
    internal class Program
    {
        public static int CharacterReplacement(string s, int k)
        {
            var letters = new HashSet<char>();
            foreach (var c in s)
                letters.Add(c);

            var maxLen = 0;
            foreach (var c in letters)
            {
                int l = 0, nonLetterCount = 0;
                for (int r = 0; r < s.Length; r++)
                {
                    if (s[r] != c)
                        nonLetterCount++;
                    while (nonLetterCount > k && l < r)
                    {
                        if (s[l] != c)
                            nonLetterCount--;
                        l++;
                    }
                    maxLen = Math.Max(maxLen, r - l + 1);
                }
            }

            return maxLen;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(CharacterReplacement("ABAB", 2));
            Console.WriteLine(CharacterReplacement("AABABBA", 1));
            Console.WriteLine(CharacterReplacement("BAAA", 0));
        }
    }
}