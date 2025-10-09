using System;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace DiceGame.Scripts
{
    internal class GameManager
    {
        public static GameManager? Instance { get; private set; }

      

        // Essential systems
        private DieRoller _roller = new DieRoller();
        
        private WorldManager _worldManager = new WorldManager();

       

        private Player _player;

        public GameManager()
        {
            Instance = this;

          

           
        }

        public void Intro()
        {
            Console.WriteLine("Enter the dungeon... If you dare!\n");
        }

        public void Play()
        {
            // Build the dungeon
            _worldManager.BuildWorld();
            // Create player
            _player = new Player();
            _worldManager.DisplayWorld(_player);
           
            // Start player movement/input
            //player.CheckInput();
        }

        public void Combat(Creature enemy)
        {
            GameLoop(_player, enemy);
        }

        private void GameLoop(Player player, Creature enemy)
        {
            int playerScore = 0;
            int enemyScore = 0;

            while (player.Health > 0 && enemy.Health > 0)
            {
                // Player chooses a weapon


                int playerRoll = player.inventory.PlayerChooseWeapon();
                playerRoll = _roller.Roll(playerRoll);

                // Enemy rolls a random weapon/die
                int enemyRoll = _roller.PickRandomDie(enemy.inventory.Weapons.Values.ToArray());
                enemyRoll = _roller.Roll(enemyRoll);
                Console.WriteLine($"{player.Name} rolled {playerRoll}");
                Console.WriteLine($"{enemy.GetType().Name} rolled {enemyRoll}");

                // Determine winner
                if (playerRoll >= enemyRoll)
                {
                    Console.WriteLine($"{player.Name} hits {enemy.GetType().Name} for {playerRoll}\n");
                    enemy.Health -= playerRoll;
                }
                else
                {
                    Console.WriteLine($"{enemy.GetType().Name} hits {player.Name} for {enemyRoll}\n");
                    player.Health -= enemyRoll;
                }

                Console.WriteLine($"{player.Name} has {player.Health} health");
                Console.WriteLine($"{enemy.GetType().Name} has {enemy.Health} health");
                Thread.Sleep(1000);
            }
            if(_player.Health <= 0)
            {
                GameOver();
            }
            Console.WriteLine("Battle Over!");
            _worldManager.DisplayWorld( _player );
        }


        private void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Another traveller swallowed by the dungeon");
            Environment.Exit(0);
        }

    }
}
