namespace _161_one_edit_distance
{
    internal class Program
    {
        public static bool IsOneEditDistance(string s, string t)
        {
            if (s == t)
                return false;

            if (Math.Abs(s.Length - t.Length) > 1)
                return false;

            if (s.Length > t.Length)
                return IsOneEditDistance(t, s);

            for (int i = 0; i < s.Length; i++)
                if (s[i] != t[i])
                {
                    if (s.Length == t.Length)
                        return s.Substring(i + 1) == t.Substring(i + 1);
                    else
                        return s.Substring(i) == t.Substring(i + 1);
                }
            return true;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(IsOneEditDistance("ab", "acb"));
            Console.WriteLine(IsOneEditDistance("ab", "ba"));
        }
    }
}