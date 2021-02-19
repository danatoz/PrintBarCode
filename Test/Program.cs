using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using PrinBarCode.DAL.DataModel;
using ex = EPPlusTest.Table;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 50;

            using (BarCodeContext db = new BarCodeContext())
            {

            }
            Program p = new Program();


            Console.WriteLine("Готово!");
            Console.ReadKey();
        }
    }
}

