using DiceGame.Scripts.HelperClasses;
using DiceGame.Scripts.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceGame.Scripts.CoreSystems
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
        public Item CombatInventory()
        {
            int choice = 0;
            Console.WriteLine("What will you do?");

            for (int i = 0; i < _inventory.Count; i++)
            {
                Item? item = _inventory[i];

                if(_inventory[i] is Weapon weapon)
                {
                    //display combat options in style
                    Console.Write($"[{i + 1}] {weapon.Name} : ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{weapon.DieRange().Start.Value}-{weapon.DieRange().End.Value} Damage");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($" : {weapon.WeaponDurability}");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                
            }
            while (true)
            {
                 choice = InputHelper.GetIntInput() - 1;

                if (choice >= 0 && choice < _inventory.Count && _inventory[choice] != null)
                    return _inventory[choice]!;

            }
        }
        /// <summary>
        /// Displays the inventory in full and allows inspecting items, optional ability to pass health values
        /// </summary>
        /// <param name="health"></param>
        /// <param name="MaxHealth"></param>
        public void ViewInventory(int? health = null, int? MaxHealth = null)
        {
            
            Console.WriteLine("\n");
            Console.WriteLine($"====INVENTORY=============");
            Console.WriteLine();
            if (health != null && MaxHealth != null)
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

            //Allow interacting with inventory
            Console.WriteLine();
            Console.WriteLine("[0] Back");
            Console.WriteLine();
            Console.WriteLine("==========================");
            int choice = InputHelper.GetIntInput();
            if (choice == 0)
                return;

            choice--;
            if (_inventory[choice] != null)
                _inventory[choice]!.ShowDetails();
              
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
