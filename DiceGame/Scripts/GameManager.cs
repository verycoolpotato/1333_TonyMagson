using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
    internal class GameManager
    {
        private int score = 0;
        public void PlayGame()
        {
            Console.WriteLine("Time to Die!");

            OnPointAquired();
        }

        public void OnPointAquired()
        {
            score++;
            string gainedMessage = "You Gained a Point!";
            Console.WriteLine(gainedMessage);
        }
    }
}
