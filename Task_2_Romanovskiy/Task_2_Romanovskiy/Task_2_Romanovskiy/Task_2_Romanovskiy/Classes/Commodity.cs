using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Romanovskiy.Classes
{
    class Commodity
    {
        public string GetName { get; set; }
        public decimal GetCost { get; set; }

        public Commodity()
        {

        }
        public Commodity(string name, decimal cost)
        {
            GetName = name;
            GetCost = cost;
        }

        public override string ToString()
        {
            return ("Name: " + GetName + "; Cost: " + GetCost);
        }
    }
}
