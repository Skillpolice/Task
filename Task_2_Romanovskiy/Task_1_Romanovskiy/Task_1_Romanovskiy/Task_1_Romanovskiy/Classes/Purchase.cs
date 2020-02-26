 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Romanovskiy.Classes
{
    public class Purchase
    {
        public string GetName { get; set; }
        public decimal GetPrice { get; set; }
        public int GetCount { get; set; }
        public Purchase ()
        {

        }

        public Purchase(string name , decimal price, int count)
        {
           GetName = name;
           GetPrice = price;
           GetCount = count;
        }

        public virtual decimal GetCost()
        {
           return (GetPrice *  GetCount); 
        }

        public override string ToString()
        {
            return ("Товар: " + GetName + "; Кол-во товара: " + GetCount+ "; Цена: " + GetPrice + "; Cтоимость: " + GetCost() + " б.р."); 
        }

        public override bool Equals(object o)
        {
            if(this == o)
            {
                return true;
            }
            else if(o == null || this.GetType() != o.GetType())
            {
                return false;
            }
            Purchase pur = (Purchase)o;
            return ((this.GetName == pur.GetName) && (this.GetPrice == pur.GetPrice));
        }
    }
}
