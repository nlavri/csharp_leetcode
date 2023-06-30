namespace _362_design_hit_counter
{
    internal class Program
    {
        public class HitCounter
        {

            private readonly SortedDictionary<int, (int Stamp, int Count)> dict = new SortedDictionary<int, (int Ts, int Count)>();

            private int HitsCount = 0;

            public HitCounter()
            {

            }

            public void Hit(int timestamp)
            {
                var bucket = timestamp % 300;
                if (bucket == 0)
                    bucket = 300;

                if (dict.ContainsKey(bucket))
                {
                    var entry = dict[bucket];
                    if (entry.Stamp == timestamp)
                    {
                        dict[bucket] = (timestamp, entry.Count + 1);
                    }
                    else
                    {
                        HitsCount -= entry.Count;
                        dict[bucket] = (timestamp, 1);
                    }
                }
                else
                {
                    dict[bucket] = (timestamp, 1);
                }
                HitsCount++;
            }

            public int GetHits(int timestamp)
            {
                var keys = dict.Keys.ToArray();

                foreach (var key in keys)
                {
                    var entry = dict[key];
                    if (entry.Stamp <= timestamp - 300)
                    {
                        HitsCount -= entry.Count;
                        dict[key] = (entry.Stamp, 0);
                    }
                }

                return HitsCount;
            }
        }

        static void Main(string[] args)
        {
            var hc = new HitCounter();

            //["HitCounter","hit","hit","hit","hit","hit","hit","getHits","hit","getHits","hit","getHits"]
            //[[],[100],[282],[411],[609],[620],[744],[879],[956],[976],[998],[1055]]

            hc.Hit(100);
            hc.Hit(282);
            hc.Hit(411);
            hc.Hit(609);
            hc.Hit(620);
            hc.Hit(744);
            Console.WriteLine(hc.GetHits(879));
            hc.Hit(956);
            Console.WriteLine(hc.GetHits(976));
            hc.Hit(998);
            Console.WriteLine(hc.GetHits(1055));

        }
    }
}