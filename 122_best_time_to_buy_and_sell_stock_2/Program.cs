namespace _122_best_time_to_buy_and_sell_stock_2
{
    internal class Program
    {
        public static int MaxProfit(int[] prices)
        {
            var maxProfit = 0;
            var len = prices.Length - 1;
            for (int i = 0; i < len; i++)
            {
                var diff = prices[i + 1] - prices[i];
                if (diff > 0)
                    maxProfit += diff;
            }

            return maxProfit;
        }

        static void Main(string[] args)
        {
            var prices = new[] { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine(MaxProfit(prices));

            prices = new[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(MaxProfit(prices));

            prices = new[] { 7, 6, 4, 3, 1 };
            Console.WriteLine(MaxProfit(prices));
        }
    }
}