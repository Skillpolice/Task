using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Romanovskiy.Classes;

namespace Task_2_Romanovskiy.Derivatives_Classes
{
    class DerivativePurchaseThree : AbstractPurchase
    {
        public int Fare { get; set; }
        public DerivativePurchaseThree()
        {
        }

        public DerivativePurchaseThree(Commodity commodity, int count,int fare) : base(commodity, count)
        {
            Fare = fare;        
        }

        public override decimal GetCost()
        {
            return ((CountProduct *CommodityCom.GetCost) + Fare);
        }

        public override string ToString()
        {
            return (base.ToString() + "; Fare = " + GetCost());
        }
    }
}
