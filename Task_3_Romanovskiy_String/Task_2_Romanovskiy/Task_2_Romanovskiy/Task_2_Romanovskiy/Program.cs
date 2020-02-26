using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Task_2_Romanovskiy.Classes;

namespace Task_2_Romanovskiy
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\in.txt";
            string outFile = @"..\..\out.txt";
            string line, result;
            SerchingMoneyRegex money = new SerchingMoneyRegex();
            SearchingDateRegex date = new SearchingDateRegex();
            StringBuilder stringBuilder = new StringBuilder();


            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {

                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        result = money.Get(line);
                        result = date.Get(result);
                        Console.WriteLine(result);
                        stringBuilder.AppendLine(result);
                    }



                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            using (StreamWriter writer = new StreamWriter(outFile, true))
            {

                writer.WriteLine(stringBuilder);
                writer.Close();
            }



            Console.ReadKey();

        }
    }
}
