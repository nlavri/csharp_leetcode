namespace _849_maximize_distance_to_closest_person
{
    internal class Program
    {
        public static int MaxDistToClosest(int[] seats)
        {
            var maxDist = 0;
            var l = 0;

            for (int i = 0; i < seats.Length; i++)
            {
                if (seats[i] == 1 || i == seats.Length - 1)
                {
                    int dist;
                    if (seats[l] == 0)
                        dist = i;
                    else if (seats[i] == 0)
                        dist = i - l;
                    else
                    {
                        var len = ((i - l) + 1);
                        var isOdd = len % 2 == 1;
                        dist = (len / 2);
                        if (!isOdd)
                            dist -= 1;
                    }

                    if (dist > maxDist)
                        maxDist = dist;

                    l = i;
                }
            }

            return maxDist;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(MaxDistToClosest(new int[] { 1, 0, 0, 0, 1, 0, 1 }));//2
            Console.WriteLine(MaxDistToClosest(new int[] { 1, 0, 0, 0 }));//3
            Console.WriteLine(MaxDistToClosest(new int[] { 1, 0, 0, 1 }));//1
            Console.WriteLine(MaxDistToClosest(new int[] { 0, 1 }));//1
        }
    }
}