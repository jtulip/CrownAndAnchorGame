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
            Dice d2 = new Dice();
            Dice d3 = new Dice();

            Player p = new Player("Fred", 100);
            Console.WriteLine(p);
            Console.WriteLine();

            Console.WriteLine("New game for {0}", p.Name);
            Game g = new Game(d1, d2, d3);
            IList<DiceValue> cdv = g.CurrentDiceValues;
            Console.WriteLine("Current dice values : {0} {1} {2}", cdv[0], cdv[1], cdv[2]);

            DiceValue rv = Dice.RandomValue;

            Random random = new Random();
            int bet = 5;
            p.Limit = 0;
            int winnings = 0;
            DiceValue pick = Dice.RandomValue;

            int totalWins = 0;
            int totalLosses = 0;

            while (true)
            {
                int winCount = 0;
                int loseCount = 0;
                for (int i = 0; i < 100; i++)
                {
                    p = new Player("Fred", 100);
                    Console.Write("Start Game {0}: ", i);
                    Console.WriteLine("{0} starts with balance {1}", p.Name, p.Balance);
                    int turn = 0;
                    while (p.balanceExceedsLimitBy(bet) && p.Balance < 200)
                    {
                        //Console.Write("Turn {0}: ", turn+1);
                        //Console.WriteLine("Player {0} betting {1} on {2}. Balance:{3}, Limit:{4}",
                        //                   p.Name, bet, Dice.stringRepr(pick), p.Balance, p.Limit);

                        try
                        {
                            p.placeBet(bet);
                            winnings = g.playRound(bet, pick);
                            cdv = g.CurrentDiceValues;

                            //Console.WriteLine("Rolled {0} {1} {2}", cdv[0], cdv[1], cdv[2]);
                            if (winnings > 0)
                            {
                                p.receiveWinnings(winnings);
                                //Console.WriteLine("{0} won {1}", p.Name, winnings);
                            }
                            else
                            {
                                //Console.WriteLine("{0} lost {1}", p.Name, bet);
                            }
                        }
                        catch (BelowLimitException e)
                        {
                            Console.WriteLine("Error: {0}", e.Message);
                            throw new Exception("Really don't expect to see this");
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine("{0}\n\n", e.Message);
                        }
                        pick = Dice.RandomValue;
                        winnings = 0;
                        turn++;
                    } //while

                    if (p.Balance >= 200) winCount++;
                    else loseCount++;
                    Console.Write("{1} turns later.\nEnd Game {0}: ", i, turn);
                    Console.WriteLine("{0} now has balance {1}\n", p.Name, p.Balance);
                } //for
                Console.WriteLine("Win count = {0}, Lose Count = {1}", winCount, loseCount);
                totalWins += winCount;
                totalLosses += loseCount;

                string ans = Console.ReadLine();
                if (ans.Equals("q")) break;
            } //while true
            Console.WriteLine("Overall loss rate = {0}%", (float)(totalLosses * 100) / (totalWins + totalLosses));
            Console.ReadLine();
        } 
    }
}
