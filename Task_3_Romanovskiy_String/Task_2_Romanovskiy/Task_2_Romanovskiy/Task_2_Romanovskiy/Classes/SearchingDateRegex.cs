using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_2_Romanovskiy.Classes
{
    public class SearchingDateRegex : SearchingRexgex
    {
        public SearchingDateRegex()
        {
        }

        public SearchingDateRegex(string str) : base(str)
        {
        }

        public override string Get(string strDate)
        {
            string datePattern = @"\b(0?[1-9]|1[0-9]|2[0-9]|3[0,1])([./-])(0?[1-9]|1[0-2])\2(([0-2][0-9])\d{2}|\d{2})\b";
            Regex regDate = new Regex(datePattern, RegexOptions.IgnoreCase);
            string tmpString = regDate.Replace(strDate, new MatchEvaluator(GetNumber));
            return tmpString;

        }

        public override string GetNumber(Match date)
        {
            string str = date.ToString();
            DateTime date1;
            if (DateTime.TryParse(str, out date1))
            {
                return (date1.ToString("MMMM dd, yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")));
            }
            else
            {
                return str;
            }
        }
    }
}
