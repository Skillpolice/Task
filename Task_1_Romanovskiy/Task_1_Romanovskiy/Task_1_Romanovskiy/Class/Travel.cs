using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Romanovskiy.Class
{

    class Travel
    {
        public const decimal TravelAllow = 125;

        string name;
        decimal cost;
        int days;

        //конструктор без параметров
        public Travel()
        {

        }

        //конструктор с параметров
        public Travel(string name, decimal cost, int days)
        {
            this.name = name;
            this.cost = cost;
            this.days = days;
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

        public decimal GetCost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }

        public int GetDays
        {
            get
            {
                return days;
            }
            set
            {
                days = value;
            }
        }

        public decimal GetTotal()
        {
            return ((TravelAllow + days) * cost);
        }

        public void Show()
        {
            Console.WriteLine("Суточные: " + TravelAllow + "\n" +"Имя: " + name + "\n" + "Транспортные расходы: " + cost + "\n" + "Количество дней: " + days);
        }

        public override string ToString()
        {
            return (TravelAllow + " ; " + name + " ; " + cost + " ; " + days + " ; ");
        }

    }
}
