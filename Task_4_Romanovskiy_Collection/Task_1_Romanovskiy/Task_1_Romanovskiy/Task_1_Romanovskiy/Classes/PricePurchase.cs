using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_1_Romanovskiy.Classes
{
    public class PricePurchase:Purchase
    {
        public decimal GetDiscount { get; set; }

        public PricePurchase()
        {
        }

        public PricePurchase(string name, decimal price, int count, decimal discount) : base(name, price, count)
        {
            GetDiscount = discount;
        }

        public override decimal GetCost()
        {
            return (GetCount * (GetPrice - GetDiscount));
        }

        public virtual string[] GetData()
        {
            string[] data = { GetName, GetPrice.ToString(), GetCount.ToString(), GetCost().ToString(), "" };
            return data;
        }
    }
}
