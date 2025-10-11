using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
    internal abstract class Consumable : Item
    {
        
        public Consumable(RarityTiers rarity) 
        {
          Rarity = rarity;
        
        }


        internal enum RarityTiers
        {
            Common = 0,
            Uncommon = 1,
            Rare = 2,
            Unique = 3
        }

        internal RarityTiers Rarity;

        protected override void DescribeItem()
        {
            Console.WriteLine($"Rarity: {Rarity}");
        }


    }
}
