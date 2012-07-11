using System;
using System.Threading;

namespace ArtificialIntelligence
{
    class Program
    {
        static void Main()
        {
            Miner miner = new Miner(0);

            for (int i = 0; i < 100; i++)
            {
                miner.Update();
                Thread.Sleep(1500);
            }
            Console.Write("\n\n\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
