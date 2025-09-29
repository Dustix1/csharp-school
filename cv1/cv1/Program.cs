using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadej jméno:");
            string name = Console.ReadLine().ToUpper();
            Console.WriteLine($"Ahoj {name}!");
        }
    }
}
