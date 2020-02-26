using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Romanovskiy.Classes;

namespace Task_2_Romanovskiy
{
    class Program
    {
        static void Main(string[] args)
        {
            Material provodOfStell = new Material("Stell",7886);
            UniformSubject uni = new UniformSubject("provod", 0.03, provodOfStell);
            Console.WriteLine(uni.ToString());

            Material provodOfMed = new Material("Med", 8500);
            uni.GetSetMat = provodOfMed;
            Console.WriteLine(uni.ToString());

            double mas = uni.GetMass();
            Console.WriteLine("Mass = " + mas);


            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
