using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using static DiceGame.Scripts.Room;


namespace DiceGame.Scripts
{
    internal class WorldManager
    {
        public static WorldManager? Instance { get; private set; }

        public Dictionary<Direction, Vector2> PossibleDirections = new Dictionary<Direction, Vector2>()
        {
            { Direction.North, new Vector2(0, 1)},
            { Direction.East, new Vector2(1, 0)},
            {Direction.South, new Vector2(0, -1)},
            {Direction.West, new Vector2(-1, 0)}
        };

        private Room[,] _rooms = new Room [5, 5];

        private Room[] _roomTypes = new Room[] {new TreasureRoom(), new MonsterRoom() };

        public Room[,] Rooms() => _rooms;

        private Random random;

        public WorldManager()
        {
            Instance = this;
            
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
                    _rooms[row, column] = random.Next(0, 2) == 0 ? new TreasureRoom() : new MonsterRoom();

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
                    _rooms[row, column].SetWorld(this);
                    _rooms[row, column].DoorBuilder();
                }
            }
        }

        public void DisplayWorld(Player player)
        {
            Room[,] rooms = _rooms;

            for (int row = 0; row < rooms.GetLength(0); row++)
            {
                for (int col = 0; col < rooms.GetLength(1); col++)
                {
                    var room = rooms[row, col];
                    if (player.CurrentRoom == room)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("[P]");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(room.RoomIcon());
                    }
                }
                Console.WriteLine();
            }
        }

      

    }
}
