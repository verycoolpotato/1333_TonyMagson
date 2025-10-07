using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DiceGame.Scripts
{
    internal class WorldManager
    {
        private Room[,] _rooms = new Room [5, 5];

        private Room[] _roomTypes = new Room[] {new TreasureRoom(), new MonsterRoom() };

        public Room[,] Rooms() => _rooms;

        private Random random;

        public WorldManager()
        {
            // Initialize Random instance once
            random = new Random();
        }
        /// <summary>
        /// Generates the world
        /// </summary>
        public void BuildWorld()
        {
            for (int row = 0; row < _rooms.GetLength(0); row++)
            {
                for (int column = 0; column < _rooms.GetLength(1); column++)
                {
                    _rooms[row, column] = _roomTypes[random.Next(0, _roomTypes.Length)];
                    _rooms[row, column].Coordinates = new System.Numerics.Vector2 (row, column);
                }
            }
            BuildDoors();
        }

        private void BuildDoors()
        {
            for (int column = 0; column < _rooms.GetLength(1); column++)
            {
                Console.WriteLine();
                for (int row = 0; row < _rooms.GetLength(0); row++)
                {
                    _rooms[row, column].DoorBuilder();
                }
            }
        }

        public void DisplayWorld()
        {
            for (int column = 0; column < _rooms.GetLength(1); column++)
            {
                Console.WriteLine();
                for (int row = 0; row < _rooms.GetLength(0); row++)
                {
                    Console.Write("[ ]");
                }
            }

        }

    }
}
