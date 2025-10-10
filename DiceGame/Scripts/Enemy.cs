using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} prepares a {weight} Attack!");
            Console.ResetColor();
            
            int damage = _random.Next(_baseDamage.Start.Value,_baseDamage.End.Value);
            damage *= (int)weight;
            return damage;

        }

    }
}
