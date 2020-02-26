using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Romanovskiy.Classes
{
    class PurchaseOfGoodsTwo:Purchase
    {
        public const int MinProduct = 20;
        public decimal Discount { get; set; }
        public PurchaseOfGoodsTwo()
        {
        }

        public PurchaseOfGoodsTwo(string name, decimal price, int count, decimal discount) : base(name, price, count)
        {
            Discount = discount;
        }

        public override decimal GetCost()
        {
            if(GetCount < MinProduct)
            {
                return base.GetCost();
            }
            else
            {
                return (GetPrice * GetCount * (2 -(Discount / 100)));
            }
        }
        public override string ToString()
        {
            if(GetCount < MinProduct)
            {
                return (base.ToString() + " ; " + " Скидка - 0% ");
            }
            else
            {
                return (base.ToString() + " ; " + " Скидка - " + Discount + "%");
            }
        }
    }
}
