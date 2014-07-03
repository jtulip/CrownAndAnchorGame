using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrownAndAnchorGame
{
    class Game
    {
        private readonly List<Dice> dice;
        private readonly List<DiceValue> values;

        public IList<DiceValue> CurrentDiceValues
        {
            get { return values.AsReadOnly(); }
        }


        public Game(Dice die1, Dice die2, Dice die3)
        {
            dice = new List<Dice>();
            values = new List<DiceValue>();
            dice.Add(die1);
            dice.Add(die2);
            dice.Add(die3);

            foreach (var die in dice)
            {
                values.Add(die.CurrentValue);
            }
        }

        public int playRound(int bet, DiceValue pick)
        {
            if (bet < 0) throw new ArgumentException("Bet cannot be negative");

            int matches = 0;
            for (int i = 0; i < dice.Count; i++)
            {
                values[i] = dice[i].roll();
                if (values[i].Equals(pick)) matches += 1;
            }

            int winnings = 0;
            if (matches > 0) winnings = matches * bet + bet;

            return winnings;
        }
    }
}
