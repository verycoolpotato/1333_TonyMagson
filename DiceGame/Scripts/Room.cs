using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
  
    internal abstract class Room
    {
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

        private WorldManager? _worldManager;

        //has this room been visited
        protected bool _visited;
        

        //Where is this room,located
        private Vector2 _worldPos;
        public Vector2 Coordinates { set { _worldPos = value; } }
        #region Connections

        public void SetWorld(WorldManager world)
        {
           
              _worldManager = world;
        }

        /// <summary>
        /// Add a connecting doorway
        /// </summary>
        /// <param name="direction"></param>
        private void AddConnection(Direction direction)
        {
           
            Connections |= direction; 
           
        }

        /// <summary>
        /// check what directions player can move from here
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool HasConnection(Direction direction)
        {
            return (Connections & direction) != 0;
        }

      

        /// <summary>
        /// Initialize doorways
        /// </summary>
        public void DoorBuilder()
        {
            
                Room[,] rooms = _worldManager!.Rooms();


            foreach (KeyValuePair<Direction, Vector2> offset in WorldManager.Instance!.PossibleDirections)
            {
                Vector2 roomPos = _worldPos + offset.Value;

                int x = (int)roomPos.X;
                int y = (int)roomPos.Y;

                //check array bounds
                if (x >= 0 && x < rooms.GetLength(0) && y >= 0 && y < rooms.GetLength(1) && rooms[x, y] != null)
                {
                    AddConnection(offset.Key);
                }
            }


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
        public virtual void OnRoomSearched(Player? player = null)
        {

        }

        protected virtual void EnteredEvent()
        {
            //Do nothing by default
        } 

        #endregion

        #region Exploration
        

        public abstract string RoomIcon();
       

        /// <summary>
        /// Describes the room and returns whether its been visited
        /// </summary>
        /// <returns></returns>
        public void OnRoomEnter()
        {
            if (_visited)
                return;
            Console.WriteLine(RoomDescription());
            
            EnteredEvent();
          
        }

        /// <summary>
        /// Marks the room as visited and prints exit message
        /// </summary>
        public void OnRoomExit()
        {
            Console.WriteLine("...Leaving Room");
            _visited = true;
        }
        #endregion

    }
}
