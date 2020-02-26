using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_3_Romanovskiy
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\input.txt";
            string fileOut = @"..\..\output.txt";
            string comentRegex = @"(?<=[\s;]|^)\/\/.+?\n";  // регулярное выражение для поиска комментариев, начинающихся с // и до конца строки.
            string commentRegex = @"(?<=[\s;]|^)(/\*[\s\S]*?(\*/))"; // регулярное выражение для поиска коментариев начинающихся с /* и заканчивающихся */
            string textIn = null;
            string textOut = null;
            try
            {
                using (StreamReader codeReader = new StreamReader(filePath))
                {

                    while (!codeReader.EndOfStream)
                    {
                        textIn = codeReader.ReadToEnd();
                    }
                }
                textOut = Regex.Replace(textIn, commentRegex, string.Empty);
                textOut = Regex.Replace(textOut, comentRegex, "\r\n");

                Console.WriteLine(textOut);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                using (StreamWriter codeWriter = new StreamWriter(fileOut))
                {
                    codeWriter.Write(textOut);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
