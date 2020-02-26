using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Romanovskiy.Classes
{
    class Segment:IComparable<Segment>,IComparer<Segment>
    {
        double x1, x2, y1, y2; //координаты отрезков
        public int Len { get; set; }
        public int Num { get; set; }

        public Segment()
        {
            Len = 0;
            Num = 0;
        }

        public Segment(string[] str)
        {
            x1 = Convert.ToDouble(str[0]);
            x2 = Convert.ToDouble(str[1]);
            y1 = Convert.ToDouble(str[2]);
            y2 = Convert.ToDouble(str[3]);
            Len = Convert.ToInt32((Math.Round((Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2))), MidpointRounding.AwayFromZero)));
            Num++;
        }

        public Segment(int len, int num = 0)
        {
            Len = len;
            Num = num;
        }

        public override string ToString()
        {
            return (Len + ";" + Num);
        }

        // IComparable позволяет сравнивать по длине
        int IComparable<Segment>.CompareTo(Segment other)
        {
            return (Len.CompareTo(other.Len));
        }

        // IComparer для сравнения количества
        int IComparer<Segment>.Compare(Segment x, Segment y)
        {
            return y.Num.CompareTo(x.Num);
        }
    }
}
