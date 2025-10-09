using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
    internal static class InputHelper
    {
        internal static int GetIntInput()
        {
            string? key = Console.ReadKey().ToString();
            int.TryParse(key, out int Selection);

            return Selection;
        }

        internal static string GetStringInput()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                return input;
            } 
        }

    }
}
