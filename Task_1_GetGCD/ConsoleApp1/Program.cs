using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.MyInterfaces;
using MyClassLibrary;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0;
            int num2 = 0;
            Console.Write("Enter number ONE int: ");
            //num1 = Convert.ToInt32(Console.ReadLine());
            string input = Console.ReadLine();
            Console.Write("Input number TWO int: ");
            string input2 = Console.ReadLine();
            if (Int32.TryParse(input, out num1) && Int32.TryParse(input2, out num2))
            {
                while (num1 < 0 || num2 < 0)
                {
                    Console.Write("ERROR, num1 < 0 !!! enter again: ");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("ERROR, num2 < 0 !!! enter again: ");
                    num2 = Convert.ToInt32(Console.ReadLine());
                }
            }
            else
            {
                Console.Write("ERROR, num1 letter or Dounble !!! enter again Intenger number: ");
                num1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("ERROR, num2 letter or Dounble !!! enter again Intenger number: ");
                num2 = Convert.ToInt32(Console.ReadLine());
            }
            ClassGcd numInt = new ClassGcd();
            Console.WriteLine("\nGCD of " + num1 + " and " + num2 + " is " + numInt.GetGcd(num1, num2));
            Console.ReadKey();
        }
    }
}
