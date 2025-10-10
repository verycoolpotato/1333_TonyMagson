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



        public override void OnRoomSearched(Player? player = null)
        {
            if (_visited)
            {
                Console.WriteLine("The room is empty");
                return;
            }
            Console.WriteLine();
            player!.inventory.PickupItem(LootTables.GetRandomItem(LootTables.CommonTreasureDrop),true);
            _visited = true;
        }
        public override string RoomIcon()
        {
            if (!_visited)
                return "[?]".PadRight(3);

            return "[T]".PadRight(3);
        }
    }
}
