using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3_OrderStringsByLength;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] strSort = { "Windows", "Bike", "table", "asdadad ", "microsoft" };
            SortMassString str = new SortMassString();
            str.OrderStringsByLength(strSort);

            Console.ReadKey();
        }

    }
}
