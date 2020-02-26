using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_CountOfWovles.MyInterfaces;

namespace Task_2_CountOfWovles
{
    public class MyCountWovels:ICountWovels
    {
        int ct = 0;

        public int CountOfWovels(string str, string wovels)
        {
            //цикл для поеска гласных 
            for (var i = 0; i < str.Length; i++)
            {
                for (var j = 0; j < wovels.Length; j++) 
                {
                    if (str[i] == wovels[j]) //проверка на совпадения гласных в словах 
                    {
                        ct++;
                    }
                }
            }
            return (ct);
        }
    }
}
