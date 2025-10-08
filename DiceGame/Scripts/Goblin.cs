using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
    internal class Goblin : Creature
    {
        public Goblin(int health = 6) : base(health)
        {
            inventory = new Inventory();
            

        }


    }
}
