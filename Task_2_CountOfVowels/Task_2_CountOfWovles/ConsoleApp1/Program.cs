using System;
using Task_2_CountOfWovles;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string str = {"my friend it's verry good"};
            string wovels = "a,u,i,e,o";
            Console.WriteLine("Input line: ");
            string str = string.Empty;
            str = Console.ReadLine();

            MyCountWovels strWovels = new MyCountWovels();
            Console.WriteLine("\nCount wovels = " + strWovels.CountOfWovels(str, wovels));

            Console.ReadKey();
        }
    }
}
