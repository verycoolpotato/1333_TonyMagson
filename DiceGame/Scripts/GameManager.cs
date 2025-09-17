using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
    internal class GameManager
    {
        public void Play()
        {
            // Welcome message with my name + date
            Console.WriteLine("Welcome to the Dice Roller! (by Tony Magson)");
            Console.WriteLine("Today is " + DateTime.Now.ToShortDateString());
            Console.WriteLine("============================================\n");

            // make the die roller
            DieRoller roller = new DieRoller();

            // roll 4 dice (d6, d8, d12, d20)
            int total = roller.Roll(6, 8, 12, 20);

            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine($"Total Score: {total}");
            Console.WriteLine("--------------------------------------------\n");

            // show how operators work
            ExplainOperators();

            // goodbye
            Console.WriteLine("\nThanks for playing, goodbye!");
        }

        private void ExplainOperators()
        {
            Console.WriteLine("C# Arithmetic Operators:\n");

            int a = 5;
            int b = 3;

            // addition
            Console.WriteLine($"{a} + {b} = {a + b}   (adds numbers)");

            // subtraction
            Console.WriteLine($"{a} - {b} = {a - b}   (subtracts numbers)");

            // multiplication
            Console.WriteLine($"{a} * {b} = {a * b}   (multiplies numbers)");

            // division
            Console.WriteLine($"{a} / {b} = {a / b}   (divides numbers, integer division)");

            // modulus
            Console.WriteLine($"{a} % {b} = {a % b}   (remainder after division)");

            // increment
            int x = a;
            x++;
            Console.WriteLine($"Starting with {a}, after x++ it becomes {x}   (increment)");

            // decrement
            int y = a;
            y--;
            Console.WriteLine($"Starting with {a}, after y-- it becomes {y}   (decrement)");
        }
    }
}

      

