

namespace DiceGame.Scripts
{
    internal class GameManager
    {
        //Establish Player names and scores variables
        private string[] _playerNames = new string[2];
        private int[] _playerScores = new int[2];

        //References to essential systems
        private DieRoller _roller = new DieRoller();
        private InventoryManager _inventory = new InventoryManager();

        
        public void Play()
        {
            //Explain and introduce the game
            GameStartText();

            //Setup new game parameters
            GameSetup();

            //Store player die choice
            int p1Die;
            int p2Die;

            //Game Loop
            for (int i = 0; i < _inventory.GameDice.Count; i++)
            {
                Console.WriteLine($"\n=====ROUND {i + 1}=====");
                p1Die = _inventory.PlayerChooseDie();
                    
                //Random die for second player
                    p2Die = _roller.PickRandomDie(_inventory.GameDice.ToArray());
                    Console.WriteLine($"{p1Die} vs {p2Die}");

                //Actual Roll
                int p1Rolled = _roller.Roll(p1Die);
                int p2Rolled = _roller.Roll(p2Die);

                // Roll Visual
                Console.WriteLine("\n");
                
                string RollText = "ROLLINGGGGG";
                foreach (char c in RollText)
                {
                    Console.Write(c);
                    Thread.Sleep(120);
                }
                Console.WriteLine($"|| {_playerNames[0]} rolled a {p1Rolled}");
                Thread.Sleep(500);
                foreach (char c in RollText)
                {
                    Console.Write(c);
                    Thread.Sleep(120);
                }
                Console.WriteLine($"|| {_playerNames[1]} rolled a {p2Rolled}");
                Thread.Sleep(1000);

                int[] rolls = {p1Rolled,p2Rolled };

                int winner = rolls.Max();
                int winnerIndex = Array.IndexOf(rolls,winner);

                Console.WriteLine("");
                Console.WriteLine($"{_playerNames[winnerIndex]} Wins this round");
                Console.WriteLine($" {+p1Rolled + p2Rolled} points");

                _playerScores[winnerIndex] += p1Rolled + p2Rolled;
                Console.WriteLine($"Total Scores: {_playerScores[0]} to {_playerScores[1]} ");
                Console.WriteLine();

            }
            
            // Show total scores
            Console.WriteLine($"\n===Total Scores===:");
            Console.WriteLine(_playerScores.Max());

            int gameWinner = _playerScores.Max();
            int gamewinnerIndex = Array.IndexOf(_playerScores, gameWinner);

            Console.WriteLine($"{_playerNames[gamewinnerIndex]} is the Winner with {gameWinner} points");
          

         
            Console.WriteLine();

            // Goodbye
            Console.WriteLine("\nGoodbye");
        }

       
       
        private string EnterName(int playernumber)
        {
            while (true)
            {
                Console.WriteLine($"Enter Player name");

                string? PlayerName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(PlayerName))
                {
                    Console.WriteLine("Player" + playernumber.ToString());
                    return "Player" + playernumber.ToString();
                    
                }
                else
                {
                    Console.WriteLine(PlayerName);
                    return PlayerName;
                    
                }
            }
        }
        //Game settings
        private void GameSetup()
        {
            // Ask for Player name
            _playerNames[0] = EnterName(1);
            _playerNames[1] = "Opponent";

            // Choose game dice
            _inventory.DiceSetup();

            //Fills the player inventories with dice
            _inventory.SetDefaultInventory();
        }

       //Introduces and explains the game
       private void GameStartText()
       {
            // Intro
            Console.WriteLine("Welcome to the DiceThing by Tony Magson");
            Console.WriteLine("\n");
            Console.WriteLine("                ======HOW TO PLAY======");
            Console.WriteLine("-Input your name and the Dice you'll be playing with");
            Console.WriteLine("-Each round players will pick a die from their inventory and roll it.");
            Console.WriteLine("-The higher roll wins and gains score equal to both die rolls.");
            Console.WriteLine("-In the event of a tie, player 1 wins because they are cool");
            Console.WriteLine("");
        }
        
       
    }
}

      

