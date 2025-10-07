using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
  
    internal abstract class Room
    {
        #region Connections

        [Flags]
        public enum Direction
        {
            None = 0,
            North = 1 << 0,  // 1
            East = 1 << 1,  // 2
            South = 1 << 2,  // 4
            West = 1 << 3   // 8
        }
        public Direction Connections { get; private set; } = Direction.None;

       private Dictionary<string, Vector2> _possibleDirections = new Dictionary<string, Vector2>() {
                { "North", new Vector2(0, 1)},
                { "East", new Vector2(1, 0)},
                {"South", new Vector2(0, -1)},
                {"West", new Vector2(-1, 0)}
            };

        private WorldManager _worldManager = new WorldManager();

        /// <summary>
        /// Add a connecting doorway
        /// </summary>
        /// <param name="direction"></param>
        private void AddConnection(Direction direction)
        {
            Connections |= direction; 
        }

        /// <summary>
        /// check if can move in a direction
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool HasConnection(Direction direction)
        {
            return (Connections & direction) != 0;
        }

        //Where is this room,located
        private Vector2 _worldPos;

        public Vector2 Coordinates {set {  _worldPos = value; }}

        /// <summary>
        /// Initialize doorways
        /// </summary>
        public void DoorBuilder()
        {
            Room[,] rooms = _worldManager.Rooms();

            

        
        }
        #endregion

        #region AbstractClasses

        /// <summary>
        /// what room is this?
        /// </summary>
        protected abstract string RoomDescription();

        /// <summary>
        /// What happens when using the search action
        /// </summary>
        public abstract void OnRoomSearched();


        #endregion

        #region Exploration
        private bool _visited;

        /// <summary>
        /// Describes the room and returns whether its been visited
        /// </summary>
        /// <returns></returns>
        protected bool OnRoomEnter()
        {
            Console.WriteLine(RoomDescription());
            return _visited;
        }

        /// <summary>
        /// Marks the room as visited and prints exit message
        /// </summary>
        protected void OnRoomExit()
        {
            Console.WriteLine("...Leaving Room");
            _visited = true;
        }
        #endregion

    }
}
