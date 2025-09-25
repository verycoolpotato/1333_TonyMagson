using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
    internal class GameManager
    {


        Dictionary<string, int>? Players = new Dictionary<string, int>();
        

        //References to essential systems
        Randomizer roller = new Randomizer();
        InventoryManager inventory = new InventoryManager();

        public void Play()
        {
            // Initialize players in dictionary
            Players!["Player1"] = 0;
            Players!["Player2"] = 0;

            // Intro
            Console.WriteLine("Welcome to the DiceThing by Tony Magson");
            Console.WriteLine("Today is " + DateTime.Now.ToShortDateString());
            Console.WriteLine("\n");

            // Ask for Player name
            Console.WriteLine("Enter your name:");
            string? playerName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(playerName))
            {
                Players!["Player1"] = 0;
            }
            else
            {
                playerName = "Player1";
            }

            // Choose game dice
            inventory.DiceSetup();

            // coin flip
            Random rng = new Random();
            bool playerFirst = rng.Next(0, 2) == 0;

            int p1Die;
            int p2Die;

            if (playerFirst)
            {
                p1Die = PlayerChooseDie();
                Console.WriteLine($"{playerName} Picked {p1Die}");

                p2Die = roller.PickRandomDie(inventory.GameDice.ToArray());
                Console.WriteLine($"Player 2 Picked {p2Die}");
            }
            else
            {
                p2Die = roller.PickRandomDie(inventory.GameDice.ToArray());
                Console.WriteLine($"Player 2 Picked {p2Die}");

                p1Die = PlayerChooseDie();
                Console.WriteLine($"{playerName} Picked {p1Die}");
            }

            // Roll
            Console.WriteLine("\nROLLINGGGGG");
            int p1Rolled = roller.Roll(p1Die);
            int p2Rolled = roller.Roll(p2Die);

            Console.WriteLine($"{playerName} Rolled {p1Rolled}");
            Console.WriteLine($"Player 2 Rolled {p2Rolled}");

            //give points
            int ScoreToGain = p1Rolled + p2Rolled;

            if (p1Rolled > p2Rolled)
            {
                Players!["Player1"] += ScoreToGain;
                Console.WriteLine($"{playerName} Won!");
            }
            else if (p2Rolled > p1Rolled)
            {
                Players!["Player2"] += ScoreToGain;
                Console.WriteLine("Player 2 Won!");
            }
            else
            {
                Console.WriteLine("TIE, Reroll");
            }

            // Show total scores
            Console.WriteLine($"\nTotal Scores:");
            Console.WriteLine($"{playerName}: {Players!["Player1"]}");
            Console.WriteLine($"Player 2: {Players!["Player2"]}");

            // Goodbye
            Console.WriteLine("\nGoodbye");
        }





        private int PlayerChooseDie()
        {
            //will also be wrapped in a loop
            Console.WriteLine($"Your Dice: {string.Join(", ", inventory.GameDice)}");
            Console.WriteLine("Select a Die to roll");
            string? dieInput = Console.ReadLine();

            if (int.TryParse(dieInput, out int dieNumber))
            {
                if (inventory.GameDice.Contains(dieNumber))
                {
                  return dieNumber;
                    
                }
                else
                {
                    Console.WriteLine("You don't have this die.");
                    return 0;
                }
            }
            return 0;
        }
        
       
    }
}

      

