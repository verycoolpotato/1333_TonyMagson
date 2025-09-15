using DiceGame.Scripts;

namespace DiceGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager manager = new GameManager();
            manager.PlayGame();
        }
    }
}
