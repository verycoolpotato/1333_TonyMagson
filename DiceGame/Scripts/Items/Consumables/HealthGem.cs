using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Items.Consumables
{
    internal class HealthGem : Consumable
    {

        public HealthGem (RarityTiers rarity, Range healing) : base(rarity, healing) { }
       
        private DieRoller _roller = new DieRoller();

        protected override void DescribeItem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A gemstone with healing properties");
            Console.ResetColor();
            Console.WriteLine($"");
            base.DescribeItem();
        }

        internal override void Use()
        {
            GameManager.Instance!.GamePlayer.Health += _roller.Roll(Die.Start.Value,Die.End.Value);  
            
        }
    }
}
