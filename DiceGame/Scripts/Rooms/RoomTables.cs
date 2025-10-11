using DiceGame.Scripts.Items.Consumables;
using DiceGame.Scripts.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Rooms
{
    internal static class RoomTables
    {
        internal static List<KeyValuePair<Func<Room>, float>> StandardFloorLayout = new List<KeyValuePair<Func<Room>, float>>()
        {
            new KeyValuePair<Func<Room>, float>(() => new TreasureRoom(), 0.2f),
            new KeyValuePair<Func<Room>, float>(() => new MonsterRoom(), 0.3f),
            new KeyValuePair<Func<Room>, float>(() => new EmptyRoom(), 0.5f),
        };





        /// <summary>
        /// Gets an item from the specified roomtable based on weights
        /// </summary>
        /// <param name="roomTable">Room table from the RoomTables</param>
        /// <returns></returns>
        public static Room GetRandomRoom(List<KeyValuePair<Func<Room>, float>> roomTable)
        {
            float totalWeight = roomTable.Sum(r => r.Value);
            float randomValue = Random.Shared.NextSingle() * totalWeight;

            foreach (var room in roomTable)
            {
                if (randomValue < room.Value)
                    return room.Key(); 
                randomValue -= room.Value;
            }

            return roomTable.Last().Key(); 
        }


    }
}
