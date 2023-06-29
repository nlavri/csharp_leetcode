namespace _340_longest_substring_with_at_most_k_Distinct_characters
{
    internal class Program
    {
        public static int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            var result = 0;

            var dict = new Dictionary<char, int>();
            var l = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                dict[c] = dict.GetValueOrDefault(c) + 1;

                while (dict.Count > k)
                {
                    var lC = s[l];
                    dict[lC]--;
                    if (dict[lC] == 0)
                        dict.Remove(lC);
                    l++;
                }

                result = Math.Max(result, i - l + 1);
            }

            return result;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(LengthOfLongestSubstringKDistinct("eceba", 2));
        }
    }
}