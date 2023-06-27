namespace _135_candy
{
    internal class Program
    {
        public static int Candy(int[] ratings)
        {
            var candies = new int[ratings.Length];
            Array.Fill(candies, 1);

            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                    candies[i] = candies[i - 1] + 1;
            }

            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                    candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
            }

            return candies.Sum();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Candy(new int[] { 1, 3, 2, 2, 1 }));//7

            Console.WriteLine(Candy(new int[] { 1, 2, 87, 87, 87, 2, 1 }));//13
        }
    }
}