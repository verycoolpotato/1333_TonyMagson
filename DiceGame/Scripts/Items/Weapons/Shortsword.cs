using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Items.Weapons
{
    internal class Shortsword : Weapon
    {

        private Range _thisDamage = new Range(3,7);
        public Shortsword(string WeaponName, Durability durability) : base(WeaponName,durability) 
        {
            Damage = _thisDamage;
            
        }
       


        protected override void DescribeItem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A common weapon, forged by any blacksmith. Despite its simplicity, it demands respect");
            Console.ResetColor();

            base.DescribeItem();
        }



    }
}
