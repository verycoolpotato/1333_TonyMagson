using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Rooms
{
    internal class EmptyRoom:Room
    {
        protected override string RoomDescription()
        {
            return "A dimly lit, mostly empty room";
        }
        public override void OnRoomSearched(Player? player = null)
        {
            if(_visited)
            {
                Console.WriteLine("The room is empty");
                return;
            }
            Item item = LootTables.GetRandomItem(LootTables.CommonDrop);
            if (item != null)
            {
                player!.inventory.PickupItem(item, true);
                Console.WriteLine("You manage to scrounge up a small reward");
            }
            else
            {
                Console.WriteLine("You searched but found nothing");
            }

                _visited = true;
            
        }

        

        public override string RoomIcon()
        {
            if (!_visited)
                return "[?]".PadRight(3);
            return "[ ]".PadRight(3);
        }



    }
}
