using DiceGame.Scripts;

namespace DiceGame
{
    internal class Program
    {
        //Initialize and start game
        static void Main(string[] args)
        {
            // make the game manager and start the game
            GameManager gm = new GameManager();
            gm.Play();
        }
    }
}
