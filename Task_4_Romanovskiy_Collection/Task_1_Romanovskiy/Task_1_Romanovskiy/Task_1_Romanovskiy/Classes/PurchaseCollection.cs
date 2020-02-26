using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task_1_Romanovskiy.Classes
{
    class PurchaseCollection 
    {
        
        List<Purchase> purchases = new List<Purchase>();
        public List<Purchase> listPurchases
        {
            get { return listPurchases; }
        }

        public Purchase this[int index]
        {
            get { return purchases[index]; }
        }

        public PurchaseCollection()
        {
            purchases = new List<Purchase>();
        }
        

        //	доступ к элементам коллекции и самой коллекции
        public PurchaseCollection(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName + ".csv"))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        try
                        {
                            listPurchases.Add(createPurchase(s));
                        }
                        catch (CsvLineException e)
                        {
                            Console.WriteLine("Ошибка " + e.Message);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл " + fileName + " не найден.");
            }

        }
        private Purchase createPurchase(string csvString)
        {
            string[] field = csvString.Split(';');
            int sizePurchase = 3;
            int sizePricePurchase = 4;
            decimal tempCost, tempDiscount;
            int tempCount;

            if (field.Count() == sizePurchase)
            {
                if (field[0] != "" && Decimal.TryParse(field[1], out tempCost) && Int32.TryParse(field[2], out tempCount))
                {
                    Purchase purchase = new Purchase { GetName = field[0], GetPrice = tempCost, GetCount = tempCount };
                    return purchase;
                }
                else
                {
                    throw new CsvLineException("Неверный формат строки: " + csvString);
                }
            }
            else if (field.Count() == sizePricePurchase)
            {
                if (field[0] != "" && Decimal.TryParse(field[1], out tempCost) && Int32.TryParse(field[2], out tempCount) && Decimal.TryParse(field[3], out tempDiscount))
                {
                    if (tempDiscount > tempCost)
                    {
                        throw new CsvLineException("Скидка превышает стоимость товара: " + csvString);
                    }
                    else
                    {
                        PricePurchase pricePurchase = new PricePurchase { GetName = field[0], GetPrice = tempCost, GetCount = tempCount, GetDiscount = tempDiscount };
                        return pricePurchase;
                    }
                }
                else
                {
                    throw new CsvLineException("Неверный формат строки: " + csvString);
                }
            }
            else
            {
                throw new CsvLineException("Неверный формат строки: " + csvString);
            }



        }

        //вставка покупки в позицию index, если index неверное значение, то добавить покупку в конец коллекции;
        public void Insert(int index, Purchase p)
        {
            if (index < listPurchases.Count)
            {
                listPurchases.Insert(index, p);
            }
            else
            {
                listPurchases.Add(p);
            }
        }

        //удаление покупки по индексу index; если ошибочный index , вернуть –1 (минус один), иначе – index;
        public int Delete(int index)
        {

            if (index < 0 && index >= listPurchases.Count)
            {
                listPurchases.RemoveAt(index);
                return index;
            }
            else 
            {
                return -1;
            }
            
        }

        //вычисление общей стоимости всех покупок в коллекции;
        public decimal TotalCost()
        {
            decimal ct = 0;
            foreach (var item in listPurchases)
            {
                ct += item.GetCost();
            }
            return ct;
        }

        //– вывод коллекции в виде таблицы + итоговая стоимость в последнюю стро-ку (см. пример ниже);
        public void Print(string headString)
        {
            Table table = new Table($"\n{headString}", new int[] { 30, 20, 20, 20, 20 }, "Name", "Price", "Count", "Cost", "Discount");
            table.TableHead();
            foreach (Purchase item in listPurchases)
            {
                table.TableLine(item.GetData());
            }
            table.TableBottom();
            table.TableLine("Total cost", "", "", TotalCost().ToString(), "");
            table.TableBottom();
            Console.WriteLine();
        }

        //сортировка коллекции выбранным способом (параметр cmp);
        public void Sort(IComparer<Purchase> cmp)
        {
            listPurchases.Sort(cmp);
        }

        
    }
}
