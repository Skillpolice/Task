using System;
using Task_4_RemoveDuplicateWords;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string lines = "My; Collections is is: My !Collections. To,be or not; To be!";
            Console.WriteLine(lines);

            //Ввод с клавиатуры
            //Console.WriteLine("Input line: ");
            //string lines = string.Empty;
            //lines = Console.ReadLine();

            ClassDupllWords words = new ClassDupllWords();
            Console.WriteLine("\nOutput Line: ");
            words.DupllWords(lines);


            Console.ReadKey();
        }
    }
}
