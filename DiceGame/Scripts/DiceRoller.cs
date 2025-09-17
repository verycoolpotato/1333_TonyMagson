using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
    public class DieRoller
    {
        private Random random;

        public DieRoller()
        {
            // Initialize Random instance once
            random = new Random();
        }

        //Takes an array of dice and returns the total rolled die values
        public int[] Roll(params int[] dice)
        {
            List<int> rolledDice = new List<int>();

            Console.WriteLine("Rolling Dice:\n");

            // Loop through each requested die
            foreach (int die in dice)
            {
                // Roll between 1 and die inclusive
                int result = random.Next(1, die + 1);
                rolledDice.Add(result);
            }

            return rolledDice.ToArray();
        }

    }

}
