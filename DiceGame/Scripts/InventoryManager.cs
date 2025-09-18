

namespace DiceGame.Scripts
{
    internal class InventoryManager
    {
        List <int> _gameDice = [];

       

        //add new die to game dice
        public void AddDieToGame(int die)
        {
            _gameDice.Append(die);
        }
        //Reset game dice
        public void ClearGameDice()
        {
            _gameDice = [];
        }
        
        //Set player inventories to game dice
        public List<int> GetDefaultInventory()
        {
            return _gameDice;
        }

        public List<int> RemoveDie(int DieToRemove, List <int> inventory)
        {
            if (inventory.Contains(DieToRemove))
            {
               inventory.Remove(DieToRemove);
               return inventory;
            }
            Console.WriteLine("You dont have this die");
            return inventory;
        }

        
    }
}
