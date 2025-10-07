

using System.Diagnostics.Contracts;

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
        private WorldManager _worldManager = new WorldManager();

        /// <summary>
        /// Introduce the game on program start
        /// </summary>
        public void Intro()
        {
            //Explain and introduce the game
            GameStartText();

            //Setup new game parameters
            GameSetup();
        }
        /// <summary>
        /// Run main gameplay sequence and scoring
        /// </summary>
        public void Play()
        {
          _worldManager.BuildWorld();
            _worldManager.BuildWorld();
            _worldManager.DisplayWorld();

        }
        private void DiceGame()
        {
            //Fills the player inventories with dice
            _inventory.SetDefaultInventory();

            //Play the game
            GameLoop();

            // Show total scores
            Console.WriteLine($"\n===Total Scores===:");
            Console.WriteLine(_playerScores.Max());

            int gameWinner = _playerScores.Max();
            int gamewinnerIndex = Array.IndexOf(_playerScores, gameWinner);

            Console.WriteLine($"{_playerNames[gamewinnerIndex]} is the Winner with {gameWinner} points");

            Console.WriteLine();

            //Check if the player would like to try again
            PlayAgain();
        }
       /// <summary>
       /// Check if the player wants to play again
       /// </summary>
       private void PlayAgain()
       {
            Console.WriteLine($"Game Finished");
            Console.WriteLine($"Would you like to play again? (yes or no)");
            while (true)
            {
                string? Answer = Console.ReadLine();

                switch (Answer)
                {
                case (null):
                    Console.WriteLine("ANSWER MEEEEE!!!!!");
                    continue;
                        
                case ("yes"):
                        ResetGame();
                        break;

                case ("no"):
                    Console.WriteLine($"Goodbye {_playerNames[0]}, I'll never forget you");
                        
                        Environment.Exit(0);
                        break;

                default:

                        break;
                }

            }
        }
        /// <summary>
        /// Main Round loop
        /// </summary>
        private void GameLoop()
        {
            //Store player die choice
            int p1Die;
            int p2Die;
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
                    //Print over time
                    Console.Write(c);
                    Thread.Sleep(120);
                }
                Console.WriteLine($"|| {_playerNames[0]} rolled a {p1Rolled}");
                Thread.Sleep(500);
                foreach (char c in RollText)
                {
                    //Print over time
                    Console.Write(c);
                    Thread.Sleep(120);
                }
                Console.WriteLine($"|| {_playerNames[1]} rolled a {p2Rolled}");
                Thread.Sleep(1000);

                int[] rolls = { p1Rolled, p2Rolled };

                //Display and determine winner of round
                int winner = rolls.Max();
                int winnerIndex = Array.IndexOf(rolls, winner);

                Console.WriteLine("");
                Console.WriteLine($"{_playerNames[winnerIndex]} Wins this round");
                Console.WriteLine($" {+p1Rolled + p2Rolled} points");

                _playerScores[winnerIndex] += p1Rolled + p2Rolled;
                Console.WriteLine($"Total Scores: {_playerScores[0]} to {_playerScores[1]} ");
                Console.WriteLine();

            }
        }
        /// <summary>
        /// Checks how the player wants to reset the game
        /// </summary>
        private void ResetGame()
        {
            Console.WriteLine("Would you like to change your game settings? (yes or no)");
            while (true)
            {
                string? input = Console.ReadLine();
                switch (input)
                {
                    case (null):
                        Console.WriteLine("yes or no?");
                        continue;

                    case ("yes"):
                        GameSetup();
                        Play();
                        break;

                    case ("no"):
                        Console.WriteLine($"Ok, Starting a new game");
                        Play();
                        break;

                    default:
                        Console.WriteLine("yes or no?");
                        continue;
                }
            }
            
            

        }
        /// <summary>
        /// Sets the name of the player at index PlayerNames
        /// </summary>
        /// <param name="playernumber"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Game settings
        /// </summary>
        private void GameSetup()
        {
            _inventory.ClearGameDice();

            // Ask for Player name
            _playerNames[0] = EnterName(1);
            _playerNames[1] = "Opponent";

            // Choose game dice
            _inventory.DiceSetup();

        }

       /// <summary>
       /// Introduces and explains the game
       /// </summary>
       private void GameStartText()
       {
            // Intro
            
            Console.WriteLine("Welcome to Tony's DiceThing");
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

      

