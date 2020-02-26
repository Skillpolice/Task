using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_1_Romanovskiy.Classes
{
    public class Purchase
    {
        public string GetName { get; set; }
        public decimal GetPrice { get; set; }
        public int GetCount { get; set; }
        public Purchase()
        {

        }

        public Purchase(string name, decimal price, int count)
        {
            GetName = name;
            GetPrice = price;
            GetCount = count;
        }

        public virtual decimal GetCost()
        {
            return (GetPrice * GetCount);
        }

        public virtual string[] GetData()
        {
            string[] data = { GetName, GetPrice.ToString(), GetCount.ToString(), GetCost().ToString(), "" };
            return data;
        }
    }
}
