using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateDay = DateTime.Now.ToString("dd");
            string dateMonth = DateTime.Now.ToString("MM");
            string dateYear = DateTime.Now.ToString("yyyy");
            string Date = $"{dateDay} {dateMonth} {dateYear}";

            List<List<string>> dateList = new List<List<string>>()
            {
                new List<string>{"2021"},
                new List<string>{"137", "138","139","140","173","174","175","176","177","178","179","180"}
            };

            Console.Write(dateList[0]);
            


            Console.Write(DateTime.Now.ToString("d"));

            Console.ReadKey();
        }
    }
}
