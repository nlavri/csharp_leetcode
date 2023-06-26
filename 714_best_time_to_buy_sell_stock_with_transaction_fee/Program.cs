namespace _714_best_time_to_buy_sell_stock_with_transaction_fee
{
    internal class Program
    {
        public static int MaxProfit(int[] prices, int fee)
        {
            if (prices.Length <= 1)
                return 0;

            int saving = -prices[0];
            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                profit = Math.Max(profit, saving + prices[i] - fee);
                saving = Math.Max(saving, profit - prices[i]);
            }

            return profit;

        }
        public static int MaxProfit2(int[] prices, int fee)
        {
            var maxProfit = 0;
            var min = prices[0];
            var len = prices.Length;
            for (int i = 0; i < len; i++)
            {
                if (prices[i] < min)
                    min = prices[i];
                var diff = prices[i] - min - fee;
                if (diff > 0)
                {
                    maxProfit += diff;
                    min = prices[i] - fee;
                }
            }

            return maxProfit;

        }
        
        static void Main(string[] args)
        {
            var arr = new[] { 1, 3, 7, 5, 10, 3 };
            Console.WriteLine(MaxProfit(arr, 3));
        }
    }
}