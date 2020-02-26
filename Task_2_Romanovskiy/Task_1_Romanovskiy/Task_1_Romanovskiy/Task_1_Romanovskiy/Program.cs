using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1_Romanovskiy.Classes;

namespace Task_1_Romanovskiy
{
    class Program
    {
        static bool flag;
        static void Main(string[] args)
        {
            Purchase[] pur =
            {
                 new Purchase ("Ручки",20, 12),
                 new Purchase ("Карандаши", 97, 100 ),
                 new PurchaseOfGoods ("Соль", 55, 120 ),
                 new PurchaseOfGoods ("Сахар", 152,  42 ),
                 new PurchaseOfGoodsTwo ("Мята", 78,  15, 2 ),
                 new PurchaseOfGoodsTwo ("Петрушка", 11, 1, 2 ),
            };

            Purchase MaxP = pur[0];
            for (int i = 0; i < pur.Length; i++)
            {
                Console.WriteLine(pur[i]);
                if (MaxP.GetCost() < pur[i].GetCost())
                {
                    MaxP = pur[i];
                }
                if (flag)
                {
                    flag = pur[i].Equals(pur[i]);
                }

            }
            Console.WriteLine("\n" + "Максимальная цена: " + MaxP.GetCost() + " б.р.");
            Console.Write("Совпадение товара по цене и названию? - " + flag);
            if (flag)
            {
                Console.Write(" ДА");
            }
            else
            {
                Console.Write(" НЕТ");
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
