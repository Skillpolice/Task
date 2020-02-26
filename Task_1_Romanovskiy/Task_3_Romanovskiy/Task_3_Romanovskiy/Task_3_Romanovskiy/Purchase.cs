using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_Romanovskiy
{
    public enum Days
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }
    public class Purchase : IComparable
    {
        string name;
        decimal price;
        int quantity;

        public Days Days
        {
            get;
        }

        public Purchase()
        {

        }

        public Purchase(string n, decimal prices, int quant, Days day)
        {
            this.name = n;
            this.price = prices;
            this.quantity = quant;
            Days = day;

        }

        public string GetName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public decimal GetPrice
        {
            get
            {
                return price;
            }
            set
            {

                price = value;
            }
        }

        public int GetQuantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }
        public decimal GetCost()
        {
            return (price * quantity);
        }

        public override string ToString()
        {
            return ("Name:" + name + "; Price:" + price + "; Quantity:" + quantity + "; GetCost: " + GetCost());
        }
        public int CompareTo(object o)
        {
            Purchase p = (Purchase)o;
            if (GetCost() > p.GetCost())
            {
                return 1;
            }
            if (GetCost() == p.GetCost())
            {
                return 0;
            }
            else
                return -1;

        }
    }
}
