using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_4_RemoveDuplicateWords.MyInterfaces;

namespace Task_4_RemoveDuplicateWords
{
    public class ClassDupllWords : IRemoveDupll
    {
        public string DupllWords(string lines)
        {
            var inputWords = lines.Split(' ',':', ';', '.', ',', '!', '?', '-').Distinct(); //distinct - Для удаления дублей , Split разбивает текст на слова используя разделитель. 
            foreach (var item in inputWords)
            {
                Console.Write(item + ' ');
            }
            return lines.ToString();
        }
    }
}
