namespace _374_guess_number_higher_or_lower
{
    internal class Program
    {
        public class GuessGame
        {
            private readonly int pick;

            public GuessGame(int pick)
            {
                this.pick = pick;
            }


            private int guess(int g)
            {
                return g == pick ? 0 : ( g > pick ? -1 : 1);
            }

            public int GuessNumber(int n)
            {

                int l = 1;
                int r = n;

                while (l <= r)
                {
                    var mid = l + (r - l) / 2;
                    var guessResult = guess(mid);
                    if (guessResult == 0)
                        return mid;
                    else if (guessResult == -1)
                        r = mid - 1;
                    else
                        l = mid + 1;
                }
                return 0;
            }
        }
        

        static void Main(string[] args)
        {
            Console.WriteLine(new GuessGame(6).GuessNumber(10));
            Console.WriteLine(new GuessGame(1).GuessNumber(1));
        }
    }
}