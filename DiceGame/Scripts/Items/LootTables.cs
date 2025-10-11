using DiceGame.Scripts.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Items
{
    internal static class LootTables
    {
        internal static List<KeyValuePair<Item, float>> CommonTreasureDrop = new List<KeyValuePair<Item, float>>()
        {
            new KeyValuePair<Item, float>(new Shortsword("Fools Shortsword", (Weapon.Durability)1), 0.5f),
            new KeyValuePair<Item, float>(new Shortsword("Knights Shortsword", Weapon.Durability.Sturdy), 0.5f),
            new KeyValuePair<Item, float>(new Shortsword("Travelers Shortsword", Weapon.Durability.Weathered), 0.5f),
            new KeyValuePair<Item, float>(new Shortsword("Broken Shortsword", Weapon.Durability.Shattered), 0.5f),
        };




        /// <summary>
        /// Gets an item from the specified loot table based on weights
        /// </summary>
        /// <param name="lootTable">Loot table from the loot tables class</param>
        /// <returns></returns>
        public static Item GetRandomItem(List<KeyValuePair<Item, float>> lootTable)
        {
            float totalWeight = lootTable.Sum(i => i.Value);
            float randomValue = Random.Shared.NextSingle() * totalWeight;

            foreach (var item in lootTable)
            {
                if (randomValue < item.Value)
                    return item.Key;
                randomValue -= item.Value;
            }

            return lootTable.Last().Key;
        }

    }
}
