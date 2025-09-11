namespace _1333_TonyMagson_Lab2
{

    class Program
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine("Tony Magson, " + DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("Hello");
            Console.WriteLine();

            int[] numbers = { 0, 1, 2, 4, 8, 16, 32, 64, 100, 255 };

            foreach (int num in numbers)
                PrintAll(num);
            

            Console.WriteLine();
            Console.WriteLine("Goodbye");
        }

        static void PrintAll(int number)
        {
            string binary = Convert.ToString(number, 2).PadLeft(8, '0');
            string hex = number.ToString("X2");

            Console.WriteLine($"Decimal: {number,3}  Binary: {binary} Hex: {hex}");
        }
    }

}
