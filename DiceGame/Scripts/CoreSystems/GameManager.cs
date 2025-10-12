using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.HelperClasses;
using DiceGame.Scripts.Items.Consumables;
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

       

        internal Player GamePlayer;

        internal GameManager()
        {
            Instance = this;
        }

        internal void Intro()
        {
            Console.WriteLine("Enter the dungeon... If you dare!\n");
        }

        public void Play()
        {
            // Build the dungeon
            _worldManager.BuildWorld();
            // Create player
            GamePlayer = new Player();
            _worldManager.DisplayWorld(GamePlayer);
           
            // Start player movement/input
            GamePlayer.CheckInput();
        }

        /// <summary>
        /// start combat with the enemy passed 
        /// </summary>
        /// <param name="enemy"></param>
        public void Combat(Enemy enemy)
        {
            CombatLoop(GamePlayer, enemy);
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
                int PlayerActions = 3;

                //Announce enemy intent
                int enemyDamage = enemy.NextAttack();
                Console.WriteLine();

                //Players turn
                int playerDamage = 0;

                while (PlayerActions > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You have {PlayerActions} Action points left this turn");
                    Console.ResetColor();
                    Console.WriteLine();
                    Item playerItem = player.inventory.CombatInventory();

                    if(playerItem.ActionPointCost <= PlayerActions)
                    {
                        if (playerItem is Weapon weapon)
                        {
                            Range dmg = weapon.DieRange();
                            weapon.Use();
                            playerDamage += _roller.Roll(dmg.Start.Value, dmg.End.Value);

                        }
                        else if (playerItem is Consumable consumable)
                        {
                            consumable.Use();
                        }

                        PlayerActions -= playerItem.ActionPointCost;
                    }
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"{playerDamage} Total Damage");
                    Console.WriteLine();
                }
               

                Console.WriteLine($"{player.Name} swings for {playerDamage}");
                Console.WriteLine($"{enemy.Name} swings for {enemyDamage}");
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
            if(GamePlayer.Health <= 0)
            {
                GameOver();
            }
            Console.WriteLine("Battle Over!");
            _worldManager.DisplayWorld( GamePlayer );
        }


        private void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Another traveller swallowed by the dungeon");
            Environment.Exit(0);
        }

    }
}
