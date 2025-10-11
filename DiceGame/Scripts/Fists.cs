using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceGame.Weapon;

namespace DiceGame.Scripts
{
    internal class Fists : Weapon
    {

        private Range _thisDamage = new Range(1,4);
        public Fists() : base("Fist",0) 
        {
            Damage = _thisDamage;
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
            Console.WriteLine($"Damage: {Damage.Start.Value}-{Damage.End.Value}");
           
            Console.WriteLine();
        }



    }
}
