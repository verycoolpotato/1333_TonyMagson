using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.HelperClasses;
using DiceGame.Scripts.Items.Weapons;
using System;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace DiceGame.Scripts.CoreSystems
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
            _player.CheckInput();
        }

        public void Combat(Enemy enemy)
        {
            CombatLoop(_player, enemy);
        }
        /// <summary>
        /// Main fight loop
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        private void CombatLoop(Player player, Enemy enemy)
        {
            
            
            while (player.Health > 0 && enemy.Health > 0)
            {
                int enemyDamage = enemy.NextAttack();
                Console.WriteLine();

                // Player chooses an item
                Item playerItem = player.inventory.PlayerChooseItem();

                int playerDamage = 0;

                if(playerItem is Weapon weapon)
                {
                    Range dmg = weapon.Damage;
                    weapon.Use();
                   playerDamage = _roller.Roll(dmg.Start.Value, dmg.End.Value);
                }
                //add logic for consumables, call use

                Console.WriteLine($"{player.Name} rolled a {playerDamage}");
                Console.WriteLine($"{enemy.Name} rolled a {enemyDamage}");
                Console.WriteLine();
                //decide roll winner
                switch (playerDamage > enemyDamage)
                {
                    case true:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"|SUCCESS| {player.Name} hit {enemy.Name} for {playerDamage} damage");
                        Console.ResetColor();
                        enemy.Health -= playerDamage;
                    break;
                    case false:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"|FAILURE| {enemy.Name} hit {player.Name} for {enemyDamage} damage");
                        Console.ResetColor();
                        player.Health -= enemyDamage;
                    break;
                }
                
                Console.WriteLine();

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
