using MyClassLibrary.MyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class ClassGcd:IGcd
    {

        public int GetGcd(int num1, int num2)
        {
            if(num1 == 0)
            {
                return num2;
            }
            if (num2 == 0)
            {
                return num1;
            }
            if (num1 == num2)
            {
                return num1;
            }
            if (num1 > num2)
            {
                return GetGcd(num1 - num2, num2);
            }

            return GetGcd(num1, num2 - num1);
        }
    }
}
