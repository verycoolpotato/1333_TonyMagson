using DiceGame.Scripts.Items.Consumables;
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
        //tables contain pre written constructors which are used to make new instances, also has an associated drop weight value
        //Treasure drops guarantee an item, drops do not
        //rarity of loot table decides general loot quality

        internal static List<KeyValuePair<Func<Item>, float>> CommonTreasureDrop = new List<KeyValuePair<Func<Item>, float>>()
        {
            //weapons
            new KeyValuePair<Func<Item>, float>(() => new Shortsword("Fools Shortsword", Weapon.Durability.Fragile), 0.3f),
            new KeyValuePair<Func<Item>, float>(() => new Shortsword("Knights Shortsword", Weapon.Durability.Sturdy), 0.3f),
            new KeyValuePair<Func<Item>, float>(() => new Shortsword("Travelers Shortsword", Weapon.Durability.Weathered), 0.5f),

            //consumables
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Common, new Range(3,7)), 1f),
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Uncommon, new Range(10,15)), 0.4f),
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Rare, new Range(20,30)), 0.1f),
        };

        internal static List<KeyValuePair<Func<Item>, float>> CommonDrop = new List<KeyValuePair<Func<Item>, float>>()
        {
            //weapons
            new KeyValuePair<Func<Item>, float>(() => new Shortsword("Fools Shortsword", Weapon.Durability.Fragile), 0.3f),
            new KeyValuePair<Func<Item>, float>(() => new Shortsword("Knights Shortsword", Weapon.Durability.Sturdy), 0.3f),
            new KeyValuePair<Func<Item>, float>(() => new Shortsword("Travelers Shortsword", Weapon.Durability.Weathered), 0.5f),

            //consumables
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Common, new Range(3,7)), 1f),
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Uncommon, new Range(10,15)), 0.4f),
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Rare, new Range(20,30)), 0.1f),

            //found nothing
             new KeyValuePair<Func<Item>, float>(() => null, 2f)
        };



        /// <summary>
        /// Gets an item from the specified loot table based on weights
        /// </summary>
        /// <param name="lootTable">Loot table from the loot tables class</param>
        /// <returns></returns>
        public static Item GetRandomItem(List<KeyValuePair<Func<Item>, float>> lootTable)
        {
            float totalWeight = lootTable.Sum(i => i.Value);
            float randomValue = Random.Shared.NextSingle() * totalWeight;

            foreach (var item in lootTable)
            {
                if (randomValue < item.Value)
                    return item.Key(); 
                randomValue -= item.Value;
            }

            return lootTable.Last().Key();
        }


    }
}
