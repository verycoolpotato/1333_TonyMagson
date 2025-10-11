using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Items.Weapons
{
    internal class Shortsword : Weapon
    {

        
        public Shortsword(string WeaponName, Durability durability) : base(WeaponName,durability, new Range(3, 7)) 
        {
            
            
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
