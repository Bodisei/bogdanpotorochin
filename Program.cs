using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaturdayNothing
{
    class Program
    {
        private static void ConfigureCUI()
        {
            Console.Title = "My rocking APP";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("********************");
            Console.WriteLine("*Hello rocking APP!*");
            Console.WriteLine("********************");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        static void Main(string[] args)
        {
            ConfigureCUI();

            Console.ReadLine();

        }
    }
}
