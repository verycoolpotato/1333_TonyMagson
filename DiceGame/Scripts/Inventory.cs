using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceGame.Scripts
{
    internal class Inventory
    {
        // Predefined weapons with their die values
        public Dictionary<string, int> Weapons = new Dictionary<string, int>()
        {
            {"Fists", 2},
            { "Sword", 5 },
            { "Knife", 3 }
        };

        // inveotyr stores name and value
        private List<(string Name, int Value)> _inventory = new List<(string, int)>();

        /// <summary>
        /// Adds a weapon to the player's inventory
        /// </summary>
        public void PickupItem(string weapon)
        {
            if (Weapons.TryGetValue(weapon, out int value))
            {
                _inventory.Add((weapon, value));
                Console.WriteLine($"{weapon} added to your inventory!");
            }
            else
            {
                Console.WriteLine($"Weapon '{weapon}' does not exist.");
            }
        }

        /// <summary>
        /// Clears the inventory
        /// </summary>
        public void ClearInventory()
        {
            _inventory.Clear();
        }

        /// <summary>
        /// Removes a weapon by value
        /// </summary>
        public bool RemoveItem(int value)
        {
            var item = _inventory.FirstOrDefault(i => i.Value == value);
            if (item != default)
            {
                _inventory.Remove(item);
                return true;
            }

            Console.WriteLine("You don't have a weapon with that value.");
            return false;
        }

        /// <summary>
        /// Prompts the player to choose a weapon from their inventory
        /// </summary>
        public int PlayerChooseWeapon()
        {
            
            while (true)
            {
                Console.WriteLine("\nYour weapons:");
                foreach (var weapon in _inventory)
                {
                    Console.WriteLine($"{weapon}");
                }

                Console.Write("Select a weapon: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int dieValue))
                {
                    var chosen = _inventory.FirstOrDefault(w => w.Value == dieValue);
                    if (chosen != default)
                    {
                        if(chosen.Name != "Fists")
                        {
                            _inventory.Remove(chosen);
                        }
                       
                        Console.WriteLine($"You selected {chosen.Name} ({chosen.Value})!");
                        return chosen.Value;
                    }
                    else
                    {
                        Console.WriteLine("You don't have a weapon with that value.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter the numeric value of a weapon.");
                }
            }
        }

        /// <summary>
        /// Returns the inventory
        /// </summary>
        public List<(string Name, int Value)> GetInventory()
        {
            return new List<(string Name, int Value)>(_inventory);
        }
    }
}
