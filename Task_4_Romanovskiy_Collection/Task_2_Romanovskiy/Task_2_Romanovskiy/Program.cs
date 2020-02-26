using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task_2_Romanovskiy.Classes;

namespace Task_2_Romanovskiy
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pattern = @"[(()]|[())[|[(;)]";
                List<Segment> segments = new List<Segment>();
                using (StreamReader reader = new StreamReader(@"..\..\in.txt"))
                {
                    string s;
                    Segment sTemp = new Segment();
                    while ((s = reader.ReadLine()) != null)
                    {
                        string sRep = Regex.Replace(s, " ", "");
                        string[] res = new string[4];
                        int i = 0;
                        foreach (string item in Regex.Split(sRep, pattern))
                        {
                            if (item != "")
                            {
                                res[i] = item;
                                i++;
                            }
                        }
                        sTemp = new Segment(res);
                        int index = segments.BinarySearch(sTemp); // IComparable<Segment>.CompareTo
                        if (index >= 0)
                        {
                            segments[index].Num++;
                        }
                        else
                        {
                            segments.Insert(~index, sTemp);
                        }
                    }
                }

                segments.Sort(new Segment());

                foreach (Segment item in segments)
                {
                    Console.WriteLine(item);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
