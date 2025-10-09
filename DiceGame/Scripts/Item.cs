using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
    internal abstract class Item
    {
        internal string? Name;

        //what can this item do 
        protected enum Commands
        {
            Use = 1,
            Inspect = 2,
           
        }

        private Commands _command;

        /// <summary>
        /// tie commands to inputs then ask player for choice
        /// </summary>
        internal virtual void ListCommands()
        {
           
            
        }

        /// <summary>
        /// What happens when this is used
        /// </summary>
        protected abstract void Use();

        /// <summary>
        /// Item description/tooltip
        /// </summary>
        protected abstract void DescribeItem();

        
        

    }
}
