using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_2_Romanovskiy.Classes
{
    public abstract class SearchingRexgex
    {
        public string GetStr { get; set; }
        public SearchingRexgex()
        {

        }
        public SearchingRexgex(string str)
        {
            GetStr = str;
        }

        public abstract string Get(string str);
        public abstract string GetNumber(Match match);
    }
}
