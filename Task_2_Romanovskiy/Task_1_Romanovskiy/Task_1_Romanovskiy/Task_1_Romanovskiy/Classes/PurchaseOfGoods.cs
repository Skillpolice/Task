using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Romanovskiy.Classes
{
    class PurchaseOfGoods:Purchase
    {
        public decimal ProductDiscount = 20;

        public PurchaseOfGoods()
        {
        }

        public PurchaseOfGoods(string name, decimal price, int count) : base(name, price, count)
        {
        }

        public override decimal GetCost()
        {
            return (GetCount * (GetPrice - ProductDiscount));
        }

        public override string ToString()
        {
            return (base.ToString() + " ; " + " Скидка " + (ProductDiscount * GetCount) + " б.р.");
        }
    }
}
