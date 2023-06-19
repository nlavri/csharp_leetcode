using System.Runtime.InteropServices;
using System.Text;

namespace _166_fraction_to_recurring_decimal
{
    internal class Program
    {
        public static string FractionToDecimal(int numerator, int denominator)
        {
            if (numerator == 0)
            {
                return "0";
            }
            StringBuilder fraction = new StringBuilder();
            // If either one is negative (not both)
            if (numerator < 0 ^ denominator < 0)
            {
                fraction.Append("-");
            }
            // Convert to Long or else abs(-2147483648) overflows
            long dividend = Math.Abs((long)numerator); ;
            long divisor = Math.Abs((long)denominator);
            fraction.Append((dividend / divisor).ToString());
            long remainder = dividend % divisor;
            if (remainder == 0)
            {
                return fraction.ToString();
            }
            fraction.Append(".");
            Dictionary<long, int> map = new Dictionary<long, int>();
            while (remainder != 0)
            {
                if (map.ContainsKey(remainder))
                {
                    fraction.Insert(map[remainder], "(");
                    fraction.Append(")");
                    break;
                }
                map[remainder] = fraction.Length;
                remainder *= 10;
                fraction.Append((remainder / divisor).ToString());
                remainder %= divisor;
            }
            return fraction.ToString();
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(FractionToDecimal(1,4));
            Console.WriteLine(FractionToDecimal(1,280));
        }
    }
}