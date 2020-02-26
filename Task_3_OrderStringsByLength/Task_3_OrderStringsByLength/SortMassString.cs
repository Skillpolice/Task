using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3_OrderStringsByLength.MyInterfaces;

namespace Task_3_OrderStringsByLength
{
    public class SortMassString : IOrderStringsByLength
    {
        public string OrderStringsByLength(string[] strSort)
        {

            Array.Sort(strSort, (x, y) => x.Length.CompareTo(y.Length)); //Сортировка через лямбда выражение (сравнение длинны слов в массиве)
            foreach (var item in strSort)
            {
                Console.WriteLine(item);
            }
            return strSort.ToString();

        }
    }
}
