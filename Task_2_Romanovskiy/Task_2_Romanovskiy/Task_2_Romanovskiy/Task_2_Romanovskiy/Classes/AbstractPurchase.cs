using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Romanovskiy.Classes
{
    abstract class AbstractPurchase : IComparable<AbstractPurchase>
    {
        public Commodity CommodityCom { get; set; }
        public int CountProduct { get; set; }
        
        public AbstractPurchase()
        {

        }
        public AbstractPurchase(Commodity commodity, int count)
        {
            CommodityCom = commodity;
            CountProduct = count;
        }

        public abstract decimal GetCost();
        public override string ToString()
        {
            return (CommodityCom + "; CountProduct " + CountProduct + "; Cost " + GetCost());
        }
        public int CompareTo(AbstractPurchase pur)
        {
            if (GetCost() > pur.GetCost())
            {
                return -1;
            }
            if (GetCost() < pur.GetCost())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
