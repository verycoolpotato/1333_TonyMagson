using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
    internal class TreasureRoom : Room
    {
        
        protected override string RoomDescription()
        {
            //Text
            return "A dusty old room filled with junk, a small glimmer escapes from beneath one of the piles";
        }

        public override void OnRoomSearched()
        {
           //Access loot table script
        }
    }
}
