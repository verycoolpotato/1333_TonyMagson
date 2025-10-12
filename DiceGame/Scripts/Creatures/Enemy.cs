using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Creatures
{
    internal class Enemy : Creature
    {
        public Enemy(int health, string name, Range Damage) : base(health,name) 
        {
            _baseDamage = Damage;
            _random = new Random();
        
        }
        private Random _random;
        private Range _baseDamage;
        private enum AttackWeight
        {
            Light =1,
            Medium = 2,
            Heavy = 3,
        }

        /// <summary>
        /// states the type of attack coming and returns the damage
        /// </summary>
        /// <returns></returns>
        internal int NextAttack()
        {
            
            AttackWeight weight = (AttackWeight)_random.Next(1,4);

            Range modifiedDamage = new Range(_baseDamage.Start.Value + (int)weight, _baseDamage.End.Value + (int)weight);

            int damage = _random.Next(modifiedDamage.Start.Value,modifiedDamage.End.Value);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} prepares a {weight} Attack ({modifiedDamage.Start.Value}-{modifiedDamage.End.Value})");
            Console.ResetColor();
            

            return damage;

        }

    }
}
