using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_Romanovskiy
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Purchase[] pur = new Purchase[] { new Purchase ("Denis", 120 , 3, Days.Monday ),
                                              new Purchase ("Alexa", 121, 5, Days.Thursday ),
                                              new Purchase ("Borya", 1201, 12,Days.Monday),
                                              new Purchase ("Alex", 222 , 33, Days.Saturday),
                                              new Purchase ("Dima", 70, 1, Days.Friday)
            };
          
            foreach (var item in pur)
            {
                Console.WriteLine(item.ToString());
            }

            //Вычислить среднюю стоимость всех покупок, найти день, в который была осуществлена покупка с максимальной стоимостью.");
            decimal sum = 0;
            Purchase maxP = pur[0];
            foreach (Purchase p in pur)
            {
                sum += p.GetPrice / pur.Length ;
                if (p.GetCost() > maxP.GetCost())
                {
                    maxP = p;
                }
            }

            Console.Write("\n" + "Средняя сумма всех покупок: " + sum);
            Console.WriteLine("\n" + "День, в которвый была осуществлена максимальная покупка: " + maxP.Days);

            Console.WriteLine("\n" + "Отсортированный массив:");
            Array.Sort(pur);
            foreach (var item in pur)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.ReadKey();


        }
    }
}
