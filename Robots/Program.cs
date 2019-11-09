using System;

namespace Robots
{
    class Program
    {
        static void Main(string[] args)
        {
            var lab = new Lab();
            Console.WriteLine("Press CTRL+C to exit.");
            Console.WriteLine("If you don't want to charge any robot just press Enter.");
            Console.WriteLine();
            Console.WriteLine();

            while (true)
            {
                lab.Update();
                Console.WriteLine("Which robot would you like to charge?");
                string input = Console.ReadLine();
                lab.ChargeUp(input, 10);
            }
        }
    }
}
