namespace _76_minimum_window_substring
{
    internal class Program
    {
        public static string MinWindow(string s, string t)
        {
            //ADOBECODEBANC
            var dict = new Dictionary<char, int>();

            foreach (var v in t)
            {
                if (!dict.ContainsKey(v))
                {
                    dict.Add(v, 0);
                }

                dict[v]++;
            }

            int right = 0;
            int left = 0;
            int counter = 0;
            int head = 0;
            int len = int.MaxValue;

            while (right < s.Length)
            {
                if (dict.ContainsKey(s[right]))
                {
                    dict[s[right]]--;

                    if (dict[s[right]] == 0)
                    {
                        counter++;
                    }
                }
                right++;

                while (counter == dict.Count)
                {
                    if (right - left < len)
                    {
                        len = right - left;
                        head = left;
                    }

                    if (dict.ContainsKey(s[left]))
                    {
                        dict[s[left]]++;

                        if (dict[s[left]] > 0)
                        {
                            counter--;
                        }
                    }

                    left++;
                }
            }

            return len == int.MaxValue ? string.Empty : s.Substring(head, len);
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(MinWindow("ADOBECODEBANC", "ABC"));

            var s = Enumerable.Range(1, 9);
        }
    }
}