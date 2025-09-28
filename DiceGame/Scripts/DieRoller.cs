

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

           

            int result = random.Next(1, die + 1);

            return result;
        }

        public int PickRandomDie(int[] choices)
        {
            int die = random.Next(0, choices.Length);

            return choices[die];
        }

    }

}
