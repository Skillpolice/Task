using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_1_Romanovskiy.Classes
{
    public class CsvLineException : Exception
    {
        public CsvLineException(string message) : base(message)
        {
        }
    }
}
