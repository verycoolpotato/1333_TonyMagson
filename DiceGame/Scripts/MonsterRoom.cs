using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
    internal class MonsterRoom:Room
    {
        protected override string RoomDescription()
        {
            return "A sillouetted figure blocks your path";
        }
        public override void OnRoomSearched(Player? player = null)
        {
            if(_visited)
            {
                Console.WriteLine("The room is empty");
                return;
            }
            Console.WriteLine("As you search in the dark you are attacked by a greedy goblin!");
            _visited = true;
            EnteredEvent();
        }

        protected override void EnteredEvent()
        {
            Enemy enemy = new Enemy(6,"Goblin",new Range(3,7));

            GameManager.Instance!.Combat(enemy);
        }

        public override string RoomIcon()
        {
            if (!_visited)
                return "[?]".PadRight(3);
            return "[M]".PadRight(3);
        }



    }
}
