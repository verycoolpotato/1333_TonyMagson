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
        public override void OnRoomSearched()
        {
            throw new NotImplementedException();
        }

    }
}
