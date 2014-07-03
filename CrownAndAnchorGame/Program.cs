using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrownAndAnchorGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice d1 = new Dice();
            Console.WriteLine("d1 currentValue = {0} {1}", d1.CurrentValue, d1.CurrentValueRepr);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("d1 rolled = {0}",d1.roll());
            }
            Console.WriteLine("\n\n");

            Player p = new Player("Fred", 100);
            Console.WriteLine("{0}\n\n",p);

            Console.ReadLine();
        }
    }
}
