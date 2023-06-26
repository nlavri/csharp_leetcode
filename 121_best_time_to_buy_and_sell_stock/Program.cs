namespace _121_best_time_to_buy_and_sell_stock
{
    internal class Program
    {
        public static int MaxProfit(int[] prices)
        {
            var maxProfit = 0;
            var min = int.MaxValue;
            for (int i = 0; i < prices.Length; i++)
                if (prices[i] < min)
                    min = prices[i];
                else
                    maxProfit = Math.Max(maxProfit, prices[i] - min);

            return maxProfit;
        }

        static void Main(string[] args)
        {
            var prices = new[] { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine(MaxProfit(prices));

            prices = new[] { 7, 6, 4, 3, 1 };
            Console.WriteLine(MaxProfit(prices));
        }
    }
}