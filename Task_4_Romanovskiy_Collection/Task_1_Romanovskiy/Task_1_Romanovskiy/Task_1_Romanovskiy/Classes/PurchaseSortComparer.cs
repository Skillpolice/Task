using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_1_Romanovskiy.Classes
{
    class PurchaseSortComparer : IComparer<Purchase>
    {
        public int Compare(Purchase x, Purchase y)
        {
            int num = x.GetName.CompareTo(y.GetName);
            if(num == 0)
            {
                if(x.GetType() == typeof(Purchase) && y.GetType() == typeof(PricePurchase))
                {
                    return -1;
                }
                else if(x.GetType() == typeof(PricePurchase) && y.GetType() == typeof(Purchase))
                {
                    return 1;
                }
                else
                {
                    return x.GetCost().CompareTo(y.GetCost());
                }
            }
            else
            {
                return num;
            }
        }
    }
}
