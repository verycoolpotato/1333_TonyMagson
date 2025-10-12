
using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.HelperClasses;
using DiceGame.Scripts.Rooms;


namespace DiceGame.Scripts.Items.Consumables
{
    internal class WorkableMetal : Consumable
    {
        
        public WorkableMetal (RarityTiers rarity) : base(rarity, new Range(1,1)) 
        {
           
            Name = $"{rarity.ToString()} WorkableMetal"; 
        }
       
        private DieRoller _roller = new DieRoller();

       

        protected override void DescribeItem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A piece of malleable metal, could be used at a forge to create new weapons");
            Console.ResetColor();
            Console.WriteLine();
            base.DescribeItem();
        }

        internal override void Use()
        {
            if(Player.CurrentRoom is ForgeRoom)
            {
                Console.WriteLine();
                Console.WriteLine($"Would you like to forge {Name} into a weapon?");
                Console.WriteLine("[1] Forge");
                Console.WriteLine("[2] Do Not");
                while (true)
                {
                    int inputConfirm = InputHelper.GetIntInput();
                    switch (inputConfirm)
                    {
                        case 1:
                            break;
                        case 2:
                            return;
                        default:
                            continue;

                    }
                    break;
                }

                Console.WriteLine("What kind of weapon will you forge?");
                Console.WriteLine("[1] One-Handed");
                Console.WriteLine("[2] Two-Handed");
                Console.WriteLine("[3] Heavy");

               
                
                while (true)
                {
                    int inputType = InputHelper.GetIntInput();
                    switch (inputType)
                    {
                        case 1:
                            Console.WriteLine("Forging a weapon...");
                            Thread.Sleep(1000);
                            //Finish later
                            break;
                    }
                }

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("This is useless without a forge");
            }
            
            
        }
    }
}
