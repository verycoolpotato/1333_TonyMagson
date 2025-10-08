

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

        /// <summary>
        /// Takes a die and rolls it, returns rolled value
        /// </summary>
        /// <param name="die"></param>
        /// <returns></returns>
        public int Roll(int die)
        {
            List<int> rolledDice = new List<int>();

            int result = random.Next(1, die);

            return result;
        }
        /// <summary>
        /// returns a random number from an int array 
        /// </summary>
        /// <param name="choices"></param>
        /// <returns></returns>
        public int PickRandomDie(int[] choices)
        {
            int die = random.Next(0, choices.Length);

            return choices[die];
        }

    }

}
