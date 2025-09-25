

namespace DiceGame.Scripts
{
    internal class GameManager
    {
        Dictionary<string, int>? Players = new Dictionary<string, int>();

        string PlayerName = "";
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

            while (true)
            {
                Console.WriteLine("Enter your name:");

                PlayerName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(PlayerName))
                {
                    Console.WriteLine("Invalid Name");
                    continue;
                }
                else
                {
                    break;
                }
            }

            // Choose game dice
            inventory.DiceSetup();

            // coin flip
            Random rng = new Random();
            bool playerFirst = rng.Next(0, 2) == 0;

            int p1Die;
            int p2Die;

            inventory.SetDefaultInventory();

            for (int i = 0; i < inventory.GameDice.Count() +1; i++)
            {
                if (playerFirst)
                {
                    p1Die = PlayerChooseDie();
                    Console.WriteLine($"{PlayerName} Picked {p1Die}");

                    p2Die = roller.PickRandomDie(inventory.GameDice.ToArray());
                    Console.WriteLine($"Player 2 Picked {p2Die}");
                }
                else
                {
                    p2Die = roller.PickRandomDie(inventory.GameDice.ToArray());
                    Console.WriteLine($"Player 2 Picked {p2Die}");

                    p1Die = PlayerChooseDie();
                    Console.WriteLine($"{PlayerName} Picked {p1Die}");
                }
                // Roll
                Console.WriteLine("\nROLLINGGGGG");
                int p1Rolled = roller.Roll(p1Die);
                int p2Rolled = roller.Roll(p2Die);

                Console.WriteLine($"{PlayerName} Rolled {p1Rolled}");
                Console.WriteLine($"Player 2 Rolled {p2Rolled}");

                //give points
                int ScoreToGain = p1Rolled + p2Rolled;

                if (p1Rolled > p2Rolled)
                {
                    Players!["Player1"] += ScoreToGain;
                    Console.WriteLine($"{PlayerName} Won!");
                }
                else if (p2Rolled > p1Rolled)
                {
                    Players!["Player2"] += ScoreToGain;
                    Console.WriteLine("Player 2 Won!");
                }
                else
                {
                    Console.WriteLine("TIE, No Points");
                }
            }
            
            // Show total scores
            Console.WriteLine($"\nTotal Scores:");
            Console.WriteLine($"{PlayerName}: {Players!["Player1"]}");
            Console.WriteLine($"Player 2: {Players!["Player2"]}");

            // Goodbye
            Console.WriteLine("\nGoodbye");
        }





        private int PlayerChooseDie()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Select a Die to roll");
            Console.WriteLine("");
            while (true)
            {
                Console.WriteLine($"Your Dice: {string.Join(", ", inventory._playerOneInventory)}");

                string? dieInput = Console.ReadLine();

                if (int.TryParse(dieInput, out int dieNumber))
                {
                    if (inventory._playerOneInventory.Contains(dieNumber))
                    {
                        inventory._playerOneInventory.Remove(dieNumber);
                        return dieNumber;

                    }
                    else
                    {
                        Console.WriteLine("You don't have this die.");
                        Console.WriteLine("\n");

                    }
                }
            }
           
            
        }
        
       
    }
}

      

