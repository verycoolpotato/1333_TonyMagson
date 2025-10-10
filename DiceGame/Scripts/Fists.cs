using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
    internal class Fists : Weapon
    {

        private Range _thisDamage = new Range(1,4);
        public Fists() : base("Fist",Durability.None) 
        {
            Damage = _thisDamage;
        }
       


        protected override void DescribeItem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Battered and bruised, a true last resort");
            Console.ResetColor();
        }



    }
}
