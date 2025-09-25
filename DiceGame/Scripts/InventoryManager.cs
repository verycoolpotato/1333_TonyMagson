namespace DiceGame.Scripts
{
    internal class InventoryManager
    {
       
        public List<int> GameDice = new List<int>();
        List<int> _playerOneInventory = new List<int>();
        List<int> _playerTwoInventory = new List<int>();

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
        public List<int> GetDefaultInventory()
        {
            return GameDice;
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

        public void DiceSetup()
        {
            // Setup game, Will be wrapped in a loop
            Console.WriteLine("Enter a die to add to the game");
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int newDie))
            {
                GameDice.Add(newDie);
                Console.WriteLine($"Die d{newDie} added.");
            }
            else
            {
                Console.WriteLine("No die added.");
            }

            Console.WriteLine("Dice Pool: " + string.Join(", ", GameDice));
        }
    }
}
