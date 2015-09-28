using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа по преобразованию числа");
            Console.WriteLine("Денежный формат {0:c}", 24/7);
            Console.WriteLine("Десятичное число {0:d5}", 24/7);
            Console.WriteLine("Число с фиксированой точкой {0:f3}", 24/7);
            Console.WriteLine("Число с запятой {0:n}", 24/7);
            Console.WriteLine("Число в представлянии експонента {0:e}", 24/7);
            Console.WriteLine("Шестнадцетиричное число {0:X}", 99999);

            Console.ReadLine();


        }
    }
}
