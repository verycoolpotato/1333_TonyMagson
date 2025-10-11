using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceGame.Scripts.Items.Weapons.Weapon;

namespace DiceGame.Scripts.Items.Weapons
{
    internal class Fists : Weapon
    {

       
        public Fists() : base("Fist",0, new Range(1, 4)) 
        {
            
            CommandActions.Clear();
        }

        protected override void DefaultCommands()
        {
            //Override all commands
        }

        protected override void DescribeItem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Battered and bruised, a true last resort");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine($"Damage: {Die.Start.Value}-{Die.End.Value}");
           
            Console.WriteLine();
        }



    }
}
