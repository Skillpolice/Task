using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_1_Romanovskiy.Classes
{
    class Table
    {
        string title; //заголовок таблицы
        int countColumns; //количество столбцов таблицы
        string[] heads; //заголовки столбцов
        int[] size; //ширина столбцов

        public Table(string title, int[] size, params string[] heads)
        {
            this.title = title;
            countColumns = heads.Length;
            this.size = size;
            this.heads = heads;
        }

        private string Line(int n)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                s.Append("═");
            }
            return s.ToString();
        }

        private string FormatString()
        {
            StringBuilder s = new StringBuilder("║");
            for (int j = 0; j < countColumns; j++)
            {
                s.Append("  {" + j + ",-" + (size[j] - 2) + "}║");
            }
            return s.ToString();
        }

        public void TableHead()
        {
            Console.WriteLine(title);
            Console.Write("╔");
            Console.Write(Line(size[0]));
            for (int j = 0; j < countColumns - 1; j++)
            {
                Console.Write("╦");
                Console.Write(Line(size[j + 1]));

            }
            Console.WriteLine("╗");

            Console.WriteLine(FormatString(), heads);
            Console.Write("╠");
            Console.Write(Line(size[0]));
            for (int j = 0; j < countColumns - 1; j++)
            {
                Console.Write("╬");
                Console.Write(Line(size[j + 1]));
            }
            Console.WriteLine("╣"); ;
        }

        public void TableLine(params string[] data)
        {
            Console.WriteLine(FormatString(), data);
        }

        public void TableBottom()
        {
            Console.Write("╚");
            Console.Write(Line(size[0]));
            for (int j = 0; j < countColumns - 1; j++)
            {
                Console.Write("╩");
                Console.Write(Line(size[j + 1]));
            }
            Console.WriteLine("╝");
        }
    }
}
