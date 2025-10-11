using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
    internal class HealthGem : Consumable
    {

        public HealthGem (RarityTiers rarity) : base(rarity) { }

        protected override void DescribeItem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A gemstone with healing properties");
            Console.ResetColor();

            base.DescribeItem();
        }

        internal override void Use()
        {
            
        }
    }
}
