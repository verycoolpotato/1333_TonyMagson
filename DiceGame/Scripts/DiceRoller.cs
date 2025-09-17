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

        // Bonus: Flexible roll method with any number of dice
        public int Roll(params int[] sides)
        {
            int total = 0;

            Console.WriteLine("Rolling Dice:\n");

            // Loop through each requested die
            foreach (int side in sides)
            {
                // Roll between 1 and 'side' inclusive
                int result = random.Next(1, side + 1);
                Console.WriteLine($"d{side} → {result}");
                total += result;
            }

            return total;
        }
    }

}
