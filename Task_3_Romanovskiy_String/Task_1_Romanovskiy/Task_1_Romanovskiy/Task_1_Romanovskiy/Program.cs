using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_1_Romanovskiy
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\in.csv";
            int numberOfElementStr = 0;
            double result = 0;
            int errorLines = 0;
            bool ct = true; 
            StringBuilder strBuilder = new StringBuilder("Result(");

            try
            {
                using (StreamReader read = new StreamReader(filePath))
                {
                    while (!read.EndOfStream)
                    {
                        string[] strArray = read.ReadLine().Split(';');
                        
                        try
                        {
                            int elementStr = int.Parse(strArray[numberOfElementStr]);
                            double number = double.Parse(strArray[elementStr]);
                            result += number;
                            if(ct)
                            {
                                strBuilder.Append(String.Format("{0:0.0#}", number));
                                ct = false;
                            }
                            else
                            {
                                strBuilder.Append((number >= 0) ? "+" : "-").AppendFormat("{0:0.0#}", Math.Abs(number));
                             
                            }
                            
                        }

                        catch (FormatException)
                        {
                            errorLines++;
                        }
                        catch (Exception)
                        {
                            errorLines++;
                        }
                    }
                    strBuilder.Append(") = ").AppendFormat("{0:0.0#}", result);
                }
                Console.WriteLine(strBuilder);
                Console.WriteLine("Error-Lines = " + errorLines);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
