using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Romanovskiy.Classes;

namespace Task_2_Romanovskiy.Derivatives_Classes
{
    class DerivativePurchaseOne : AbstractPurchase
    {
        public decimal Discount { get; set; }
        public DerivativePurchaseOne()
        {

        }

        public DerivativePurchaseOne(Commodity commodity, int count, decimal discount) : base(commodity, count)
        {
            Discount = discount;
        }

        public override decimal GetCost()
        {
            return (CountProduct * (CommodityCom.GetCost  - Discount));
        }

        public override string ToString()
        {

            return (base.ToString() + "; Скидка " + GetCost() + "%");
        }
    }
}
