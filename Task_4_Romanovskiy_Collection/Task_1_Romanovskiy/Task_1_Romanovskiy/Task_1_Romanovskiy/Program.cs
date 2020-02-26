using Task_1_Romanovskiy.Classes;
using System.Linq;
using System;

namespace Task_1_Romanovskiy
{
    class Program
    {
        static void Main(string[] args)
        {
            //	создать объект разработанного класса и загрузить в него данные из основного файла
            PurchaseCollection purColl_1 = new PurchaseCollection(args[0]);

            //вывести коллекцию покупок на консоль (метод Print())
            purColl_1.Print("После создания");

            //создать второй объект разработанного класса и загрузить в него данные из дополнительного файла
            PurchaseCollection purColl_2 = new PurchaseCollection(args[1]);

            //вставить последний элемент второй коллекции в позицию 0 первой коллекции покупок
            purColl_1.Insert(0, purColl_2.listPurchases.Last());

            //	вставить первый элемент второй коллекции в позицию 1000 первой коллекции покупок
            purColl_1.Insert(1000, purColl_2.listPurchases[0]);

            //	вставить элемент с позицией 2 из второй коллекции в позицию 2 первой коллекции покупок
            purColl_1.Insert(2, purColl_2.listPurchases[2]);

            //последовательно удалить элементы через метод Delete(…) с индексами 3, 10 и –5
            purColl_1.Delete(3);
            purColl_1.Delete(10);
            purColl_1.Delete(-5);

            //	вывести первую коллекцию на экран;
            purColl_1.Print("До сортировки ");

            //	отсортировать первую коллекцию методом Sort(…);
            PurchaseSortComparer cmp = new PurchaseSortComparer();
            purColl_1.Sort(cmp);

            //	найти через метод binarySearch( ) коллекции List<…> элементы с ин-дексами 1 и 3 из второй коллекции в первой коллекции и вывести результаты поиска.
            int index;
            index = purColl_1.listPurchases.BinarySearch(purColl_2[1], cmp);
            if(index >= 0)
            {
                Console.WriteLine($"Элемент {purColl_2[1].GetName};{purColl_2[1].GetPrice};{purColl_2[1].GetCount} найден в позиции {index}");
            }
            else
            {
                Console.WriteLine($"Элемент {purColl_2[1].GetName};{purColl_2[1].GetPrice};{purColl_2[1].GetCount} не найден ");
            }

            index = purColl_1.listPurchases.BinarySearch(purColl_2[3], cmp);
            if (index >= 0)
            {
                Console.WriteLine($"Элемент {purColl_2[1].GetName};{purColl_2[1].GetPrice};{purColl_2[1].GetCount} найден в позиции {index}");
            }
            else
            {
                Console.WriteLine($"Элемент {purColl_2[1].GetName};{purColl_2[1].GetPrice};{purColl_2[1].GetCount} не найден ");
            }

            index = purColl_1.listPurchases.BinarySearch(purColl_2[0], cmp);
            if (index >= 0)
            {
                Console.WriteLine($"Элемент {purColl_2[1].GetName};{purColl_2[1].GetPrice};{purColl_2[1].GetCount} найден в позиции {index}");
            }
            else
            {
                Console.WriteLine($"Элемент {purColl_2[1].GetName};{purColl_2[1].GetPrice};{purColl_2[1].GetCount} не найден ");
            }


            Console.ReadKey();

        }
    }
}
