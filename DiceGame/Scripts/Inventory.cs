using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceGame.Scripts
{
    internal class Inventory
    {


        // inventory stores name and value
        private List<Item?> _inventory = new List<Item?>(9) {null,null,null,null, null, null, null, null, null};


        /// <summary>
        /// Adds an item to the player's inventory
        /// </summary>
        public void PickupItem(Item GrabbedItem, bool AnnouncePickup)
        {
            foreach (Item? item in _inventory)
            {
                if (item == null)
                {
                    if (AnnouncePickup)
                    {
                        Console.WriteLine($"Picked Up {GrabbedItem.Name}");
                    }
                   int index = _inventory.IndexOf(item);
                    _inventory[index] = GrabbedItem;
                    return;
                }
                   
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your inventory is full, free up some space");
            Console.ResetColor();
        }

        /// <summary>
        /// Clears the inventory
        /// </summary>
        public void ClearInventory()
        {
            for (int i = 0; i < _inventory.Count; i++)
            {
                _inventory[i] = null;
            }
                
        }

        /// <summary>
        /// Removes an item by index
        /// </summary>
        public void RemoveItemindex(int index)
        {
            _inventory[index] = null;
        }

        /// <summary>
        /// Removes an item by type
        /// </summary>
        public void RemoveItemType(Item item)
        {
            if (_inventory.Contains(item))
            {
               int index = _inventory.IndexOf(item);
                _inventory[index] = null;
            }
                
        }

        /// <summary>
        /// Prompts the player to choose an item from their inventory
        /// </summary>
        public Item PlayerChooseItem()
        {
            int choice = 0;
            Console.WriteLine("What will you do?");

            ViewInventory();
            while (true)
            {
                choice = InputHelper.GetIntInput();
                if (_inventory[choice] != null)
                    return _inventory[choice]!;

            }
        }

        public void ViewInventory(int? health = null, int? MaxHealth = null)
        {
            Console.WriteLine("\n");
            if(health != null && MaxHealth != null)
            {
                Console.WriteLine($"{health}/{MaxHealth} Health");
            }
            
            Console.WriteLine();
            for (int i = 0; i < _inventory.Count; i++)
            {
                if (_inventory[i] != null)
                    Console.WriteLine($"[{i + 1}] {_inventory[i].Name}");
                else
                    Console.WriteLine($"[{i + 1}] Empty");
            }
        }

        /// <summary>
        /// Returns the inventory
        /// </summary>
        public List<Item?> GetInventory()
        {
            return _inventory;
        }
    }
}
