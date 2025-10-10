using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceGame.Scripts
{
    internal class Inventory
    {
        

        // inventory stores name and value
        private List<Item?> _inventory = new List<Item?>(9);

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
                        Console.WriteLine($"Picked Up {GrabbedItem}");
                    }
                    _inventory.Add(GrabbedItem);
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
        public int PlayerChooseItem()
        {
            Console.WriteLine("What will you do?");

            ViewInventory();
           while (true)
            {
               int choice = InputHelper.GetIntInput();
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
                    Console.WriteLine($"[{i.ToString()}] {_inventory[i]}");
                else
                    Console.WriteLine($"[{i}] Empty");
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
