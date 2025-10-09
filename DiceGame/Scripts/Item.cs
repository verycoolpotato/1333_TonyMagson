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

        /// <summary>
        /// What shows up when an item is inspected
        /// </summary>
        internal virtual void Inspect()
        {
            DescribeItem();
        }

        internal int GetInput()
        {
            string? key = Console.ReadKey().ToString();
            int.TryParse(key, out int Selection);

            return Selection;
        }

        /// <summary>
        /// What happens when this is used
        /// </summary>
        internal abstract void Use();


        protected abstract void DescribeItem();

        

    }
}
