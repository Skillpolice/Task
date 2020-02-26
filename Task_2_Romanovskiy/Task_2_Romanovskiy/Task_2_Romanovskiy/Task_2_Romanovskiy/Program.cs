using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Romanovskiy.Classes;
using Task_2_Romanovskiy.Derivatives_Classes;

namespace Task_2_Romanovskiy
{
    class Program
    {

        public const int Arr = 6;
        private static void Show(object[] arrShow)
        {
            foreach (AbstractPurchase item in arrShow)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            Commodity phone = new Commodity("Phone Xiaomi", 780);
            Commodity headPhone = new Commodity("HeadPhone Xiaomi", 50);
            Commodity powerBank = new Commodity("PowerBank Xiaomi", 45);

            AbstractPurchase[] abstractPurchase = new AbstractPurchase[Arr];
            {
                abstractPurchase[0] = new DerivativePurchaseOne(phone, 20, 50);
                abstractPurchase[1] = new DerivativePurchaseOne(phone, 55, 55);
                abstractPurchase[2] = new DerivativePurchaseThree(powerBank, 17, 25);
                abstractPurchase[3] = new DerivativePurchaseThree(powerBank, 10, 55);
                abstractPurchase[4] = new DerivativePurchaseTwo(headPhone, 5, 5);
                abstractPurchase[5] = new DerivativePurchaseTwo(headPhone, 15, 5);
            };

            foreach (var item in abstractPurchase)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n" + "SortMass: ");
            Array.Sort(abstractPurchase);
            Show(abstractPurchase);

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
