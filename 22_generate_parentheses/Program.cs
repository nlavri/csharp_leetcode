// See https://aka.ms/new-console-template for more information

void Generate(string str, int opened, int closed, int n)
{
    if (str.Length == 2 * n)
    {
        Console.WriteLine(str);
        return;
    }
    if (opened < n)
        Generate(str + "(", opened + 1, closed, n);
    if (closed < opened)
        Generate(str + ")", opened, closed + 1, n);

}

Generate(String.Empty, 0, 0, 3);

