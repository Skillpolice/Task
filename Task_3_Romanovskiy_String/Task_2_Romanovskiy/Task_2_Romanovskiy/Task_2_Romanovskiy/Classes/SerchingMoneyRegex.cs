using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_2_Romanovskiy.Classes
{
    public class SerchingMoneyRegex : SearchingRexgex
    {
        public SerchingMoneyRegex()
        {
        }

        public SerchingMoneyRegex(string str) : base(str)
        {
        }

        public override string Get(string strMoney)
        {
            Regex tempReg = new Regex(@"\b(\d{1}|\d{2}|\d{3})\s+(\d{3}\s+)*(blr|belarusian roubles)", RegexOptions.IgnoreCase);
            string temp = tempReg.Replace(strMoney, new MatchEvaluator(GetNumber));
            return temp;
        }

        public override string GetNumber(Match match)
        {
            int ct;
            string x = match.ToString();
            ct = x.IndexOf("b");
            string end = x.Substring(ct);
            x = x.Remove(ct);

            Regex reg = new Regex(@"\s", RegexOptions.IgnoreCase);
            x = reg.Replace(x, "");

            return (x + " " + end);
        }
    }
}
