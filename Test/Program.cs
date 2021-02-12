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
                var employe = db.Employees.Where(p => p.Role.RoleName == "Оператор");
                foreach (var e in employe)
                {
                    Console.WriteLine("{0} {1} {2}", e.Name, e.Surname, e.Role);
                }
            }



            Console.WriteLine("Готово!");
            Console.ReadKey();
        }
    }
}
