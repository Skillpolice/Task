using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1_Romanovskiy.Class;

namespace Task_1_Romanovskiy
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 Создать массив из пяти объектов, элемент с индексом 2 должен быть пустым, последний элемент должен быть создан с использованием конструк-тора по умолчанию, остальные – с использованием конструктора с параметрами
            Travel[] travel = new Travel[5];
            travel[0] = new Travel("Denis", 20, 15);
            travel[1] = new Travel("Diana", 32, 10);
            travel[2] = null;
            travel[3] = new Travel("Alex", 13, 233);
            travel[4] = new Travel();

            foreach (Travel item in travel)
            {
                if (item != null)
                {
                    Console.WriteLine();
                    item.Show();
                }
            }

            travel[travel.Length-1].GetCost = 120;
            //Console.WriteLine(travel[4].GetCost + "\n");
           
            int days = travel[0].GetDays;
            int days1 = travel[1].GetDays;
            int sumDays = days + days1;
            Console.WriteLine("Кол_во двух первых командировок: " + sumDays);
            Console.WriteLine();
            foreach (Travel item in travel)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                }
            }


            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
