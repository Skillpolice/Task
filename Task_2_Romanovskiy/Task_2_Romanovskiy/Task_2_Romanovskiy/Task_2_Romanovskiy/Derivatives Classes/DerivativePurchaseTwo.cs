using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Romanovskiy.Classes;

namespace Task_2_Romanovskiy.Derivatives_Classes
{
    class DerivativePurchaseTwo : AbstractPurchase
    {
        public const int MinProduct = 15;
        public decimal Discount { get; set; }
        public DerivativePurchaseTwo()
        {
        }

        public DerivativePurchaseTwo(Commodity commodity, int count, decimal discount) : base(commodity, count)
        {
            Discount = discount;
        }

        public override decimal GetCost()
        {
            if (CountProduct >= MinProduct)
            {
                return (CountProduct * (CommodityCom.GetCost - Discount));
            }
            else
            {
                return (CountProduct * CommodityCom.GetCost);
            }
        }

        public override string ToString()
        {
            if (CountProduct < MinProduct)
            {
                return (base.ToString() + " ; " + " Скидка - 0% ");
            }
            else
            {
                return (base.ToString() + " ; " + " Скидка - " + GetCost() + "%");
            }
        }
    }
}
