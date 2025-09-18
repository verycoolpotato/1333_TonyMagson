using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
{
    internal class GameManager
    {
       List <int> _playerOneInventory = [];
       List <int> _playerTwoInventory = [];
        public void Play()
        {
            // Welcome message with name + date
            Console.WriteLine("Welcome to the DiceThing (by Tony Magson)");
            Console.WriteLine("Today is " + DateTime.Now.ToShortDateString());
            Console.WriteLine("\n");


            //Allow player to add as many dice of any values as they want
            Console.WriteLine("Enter a ");
            

            // make the die roller
            DieRoller roller = new DieRoller();

            

            

            int totalScore = 0;

            Console.WriteLine("+++++++");
            for (int roll = 0; roll < results.Length; roll++)
            {
                //Console.WriteLine($"d{diceList[roll],-3} rolled a {results[roll],2}");
                totalScore += results[roll];
            }
            Console.WriteLine("");
            Console.WriteLine($"Your Score is {totalScore}");

            Console.WriteLine("+++++++\n");

            // show how operators work
            ExplainOperators();

            // goodbye
            Console.WriteLine("\nGoodbye");
        }

        private void ExplainOperators()
        {
            Console.WriteLine("Operators and Examples\n");

            // addition
            Console.WriteLine($"2 + 2 = 4   (adds numbers)");

            // subtraction
            Console.WriteLine($"4 - 2 = 2  (subtracts numbers)");

            // multiplication
            Console.WriteLine($"2 * 2 = 4   (multiplies numbers)");

            // division
            Console.WriteLine($" 10 / 2 = 5   (divides numbers, integer division)");

            // modulus
            Console.WriteLine($"5 % 3 = 2   (remainder after division)");

            // increment
            Console.WriteLine($" x = 0 after x++ it becomes 1  (increment)");

            // decrement
            Console.WriteLine($"y = 1, after y-- it becomes 0   (decrement)");
        }
    }
}

      

