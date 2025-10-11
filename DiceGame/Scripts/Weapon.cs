using DiceGame.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    internal abstract class Weapon : Item
    {
        internal enum Durability
        {
            Unbreakble = 0,
            Sturdy = 1,
            Weathered = 2,
            Fragile = 3,
            Shattered = 4,
            
        }


        public Range Damage {  get; protected set; }

        /// <summary>
        /// Describe weapon specific attributes
        /// </summary>
        protected override void DescribeItem()
        {
            Console.WriteLine();
            Console.WriteLine("Weapon");
            Console.WriteLine($"Damage: {Damage.Start.Value}-{Damage.End.Value}");
            Console.WriteLine($"Durability: {WeaponDurability}");
            Console.WriteLine();
        }


        internal Durability WeaponDurability;
        private Random _random;
        internal Weapon(string WeaponName, Durability durability)
        {
            CommandActions["Rename"] = Rename;

            Name = WeaponName;
            WeaponDurability = durability;
            _random = new Random();
        }

        
        /// <summary>
        /// allow weapon renaming
        /// </summary>
        protected virtual void Rename()
        {
            Console.WriteLine($"Enter a new name for your {Name}:");
            Name = InputHelper.GetStringInput();
        }

        /// <summary>
        /// called after being swung, lowers durability
        /// </summary>
        internal override void Use()
        {
            

            if (WeaponDurability != Durability.Unbreakble)
            {
                if (_random.Next(0, 2) == 0) // 50% chance
                {
                    if (WeaponDurability < Durability.Shattered)
                    {
                        WeaponDurability = (Durability)((int)WeaponDurability + 1);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"{Name?.ToUpper()} DAMAGED");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                }
            }
        }



    }
}
