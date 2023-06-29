using System.Text;

namespace _71_simplify_path
{
    internal class Program
    {

        public static string SimplifyPath(string path)
        {
            var split = path.Split('/');
            split = split.Where(x => !string.IsNullOrEmpty(x) && x != ".").ToArray();

            var list = new List<string>();
            foreach (var str in split)
            {
                if (str == "..")
                {
                    if (list.Count > 0)
                        list.RemoveAt(list.Count - 1);
                }
                else
                {
                    list.Add(str);
                }
            }

            return "/" + string.Join('/', list);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(SimplifyPath("/a/./b/../../c/"));
        }
    }
}