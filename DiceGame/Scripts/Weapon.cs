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
            None = 0,
            Sturdy = 1,
            Weathered = 2,
            Fragile = 3,
            Shattered = 4,
            
        }


        public Range Damage {  get; protected set; }


        protected override void DescribeItem()
        {
            Console.WriteLine();
            Console.WriteLine($"Damage: {Damage.Start.Value}-{Damage.End.Value}");
            Console.WriteLine($"Durability: {_durability}");
            Console.WriteLine();
        }


        private Durability _durability;
        private Random _random;
        internal Weapon(string WeaponName, Durability durability)
        {
            CommandActions["Rename"] = Rename;

            Name = WeaponName;
            _durability = durability;
            _random = new Random();
        }

        

        protected virtual void Rename()
        {
            Console.WriteLine($"Enter a new name for your {Name}:");
            Name = InputHelper.GetStringInput();
        }
        internal override void Use()
        {
            Console.WriteLine(_durability.ToString());

            if (_durability != Durability.None)
            {
                if (_random.Next(0, 2) == 0) // 50% chance
                {
                    if (_durability < Durability.Shattered)
                    {
                        _durability = (Durability)((int)_durability + 1);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{Name} was damaged");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                }
            }
        }



    }
}
