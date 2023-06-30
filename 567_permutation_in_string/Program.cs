namespace _567_permutation_in_string
{
    internal class Program
    {
        public static bool CheckInclusion(string s1, string s2)
        {
            if (s2.Length < s1.Length)
                return false;
            if (s1 == s2)
                return true;

            var s1Dict = new Dictionary<char, int>();
            foreach (var c in s1)
                s1Dict[c] = s1Dict.GetValueOrDefault(c) + 1;

            var s2Dict = new Dictionary<char, int>();
            for (int r = 0; r < s2.Length; r++)
            {
                var s2c = s2[r];
                s2Dict[s2c] = s2Dict.GetValueOrDefault(s2c) + 1;

                if (r >= s1.Length - 1)
                {
                    var found = true;
                    foreach (var kvp in s2Dict)
                    {
                        if (s1Dict.GetValueOrDefault(kvp.Key) != kvp.Value)
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                        return true;

                    var cToRemove = s2[r - (s1.Length - 1)];
                    s2Dict[cToRemove]--;
                    if (s2Dict[cToRemove] == 0)
                        s2Dict.Remove(cToRemove);
                }
            }

            return false;
        }
        
        static void Main(string[] args)
        {
            string s1 = "ab", s2 = "eidbaooo";
            Console.WriteLine(CheckInclusion(s1, s2));

            s1 = "ab";
            s2 = "eidboaoo";
            Console.WriteLine(CheckInclusion(s1, s2));

        }
    }
}