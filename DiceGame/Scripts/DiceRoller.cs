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

        //Takes a die and rolls it, returns rolled value
        public int Roll(int die)
        {
            List<int> rolledDice = new List<int>();

            Console.WriteLine("Rolling Dice:\n");

            int result = random.Next(1, die + 1);

            return result;
        }

    }

}
