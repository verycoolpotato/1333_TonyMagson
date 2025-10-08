using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
    internal abstract class Creature
    {
        internal int Health;
        internal string Name;

        internal Inventory inventory;

        protected Creature(int health)
        {
            Health = health;
           
        }
        protected Creature(int health, string name)
        {
            Health = health;
            Name = name;
        }

        

        

    }
}
