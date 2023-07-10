namespace _2241_design_an_ATM_machine
{
    internal class Program
    {
        public class ATM
        {
            class ATMEntry
            {
                public int Denom;

                public long Count;

                public ATMEntry(int denom, long count)
                {
                    Denom = denom;
                    Count = count;
                }
            }

            private readonly ATMEntry[] storage;

            public ATM()
            {
                this.storage = new ATMEntry[]
                {
                    new ATMEntry(20, 0),
                    new ATMEntry(50, 0),
                    new ATMEntry(100, 0),
                    new ATMEntry(200, 0),
                    new ATMEntry(500, 0),
                };
            }

            public void Deposit(int[] banknotesCount)
            {
                for (int i = 0; i < banknotesCount.Length; i++)
                    this.storage[i].Count += banknotesCount[i];
            }

            public int[] Withdraw(int amount)
            {
                var tx = new int[storage.Length];

                for (int i = storage.Length - 1; i >= 0 && amount >= 0; i--)
                {
                    var currNote = storage[i];
                    long noteCount = amount / currNote.Denom;
                    tx[i] = (int)Math.Min(noteCount, currNote.Count);
                    amount -= tx[i] * currNote.Denom;
                }

                if (amount == 0)
                {
                    for (int txI = 0; txI < storage.Length; txI++)
                        storage[txI].Count -= tx[txI];

                    return tx;
                }

                return new int[] { -1 };
            }
        }

        static void Main(string[] args)
        {
            //[[],[[0,0,1,2,1]],[600],[[0,1,0,1,1]],[600],[550]]
            var atm = new ATM();

            atm.Deposit(new[] { 0, 0, 1, 2, 1 });
            
            var tx = atm.Withdraw(600);
            foreach (var v in tx)
                Console.Write(v + ",");
            Console.WriteLine(Environment.NewLine + "---------");

            atm.Deposit(new[] { 0, 1, 0, 1, 1 });

            tx = atm.Withdraw(600);
            foreach (var v in tx)
                Console.Write(v + ",");
            Console.WriteLine(Environment.NewLine + "---------");

            tx = atm.Withdraw(550);
            foreach (var v in tx)
                Console.Write(v + ",");
            Console.WriteLine(Environment.NewLine + "---------");
        }
    }
}