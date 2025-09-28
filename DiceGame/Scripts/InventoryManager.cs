namespace DiceGame.Scripts
{
    internal class InventoryManager
    {
       
        public List<int> GameDice = new List<int>(0);
       public List<int> _playerOneInventory = new List<int>();
       public List<int> _playerTwoInventory = new List<int>();

        // Add new die to game dice
        public void AddDieToGame(int die)
        {
            GameDice.Add(die); 
        }

        // Reset game dice
        public void ClearGameDice()
        {
            GameDice = new List<int>(); 
        }

        // Set player inventories to game dice
        public void SetDefaultInventory()
        {
            _playerOneInventory = new List<int>(GameDice);
            _playerTwoInventory = new List<int>(GameDice);
        }

        public List<int> RemoveDie(int DieToRemove, List<int> inventory)
        {
            if (inventory.Contains(DieToRemove))
            {
                inventory.Remove(DieToRemove);
                return inventory;
            }
            Console.WriteLine("You dont have this die");
            return inventory;
        }
        public int PlayerChooseDie()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Select a Die to roll");
            Console.WriteLine("");
            while (true)
            {
                Console.WriteLine($"Your Dice: {string.Join(", ", _playerOneInventory)}");

                string? dieInput = Console.ReadLine();

                if (int.TryParse(dieInput, out int dieNumber))
                {
                    if (_playerOneInventory.Contains(dieNumber))
                    {
                        _playerOneInventory.Remove(dieNumber);
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
        public void DiceSetup()
        {
            Console.WriteLine("Enter a die to add to the game");
            while (true)
            {
                // Setup game
                
                string? input = Console.ReadLine();

                
                if (string.IsNullOrWhiteSpace(input))
                {
                    if (GameDice.Count() <= 0)
                    {
                        Console.WriteLine("Please add a die");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Dice Confirmed");
                        Console.WriteLine("Dice Pool: " + string.Join(", ", GameDice));

                        break;
                    }
                        
                }
                if (int.TryParse(input, out int newDie))
                {
                    GameDice.Add(newDie);

                    Console.WriteLine(string.Join(", ", GameDice) + " || Add another die or leave empty to confirm");
                    continue;
                }
                else 
                {
                    Console.WriteLine("Not a valid die");
                    continue;
                }

               
            }
            
        }
    }
}
