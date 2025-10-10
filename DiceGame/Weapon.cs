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

        
        
        private Durability _durability;
        private Random _random;
        internal Weapon(string WeaponName, Durability durability)
        {
            Name = WeaponName;
            _durability = durability;
            _random = new Random();
            
        }

        protected void Rename()
        {
            Console.WriteLine($"Enter a new name for your {GetType().Name}");
            Name = InputHelper.GetStringInput();
            
        }

        

        internal override void Use()
        {
            if (_durability != Durability.None)
            {
                if (_random.Next(0, 3) == 0)
                {
                    _durability = (Durability)((int)_durability + 1);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{Name} was damaged");
                    Console.ResetColor();
                    
                }
            }
        }

        

    }
}
