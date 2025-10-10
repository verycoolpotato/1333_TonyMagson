using DiceGame.Scripts;

namespace DiceGame
{
    internal class Program
    {
        //Initialize and start game
        static void Main(string[] args)
        {

            Console.Title = "Dungeon Smith";
          
            // make the game manager and start the game
            GameManager Manager = new GameManager();
            Manager.Intro();
            Manager.Play();
        }

    }
}
