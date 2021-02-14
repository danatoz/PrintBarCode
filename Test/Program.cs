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
            p.GetUsers();


            Console.WriteLine("Готово!");
            Console.ReadKey();
        }
        public List<PrinBarCode.DAL.DataModel.Employee> GetUsers()
        {
            using (BarCodeContext db = new BarCodeContext())
            {
                var employeeList = db.Employees.Select(p => new
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Password = p.Password
                }).ToList();
                foreach (var e in employeeList)
                {
                    Console.WriteLine("{0} {1} {2}", e.Name, e.Surname, e.Password);
                }
                return employeeList;

            }
        }
    }
}

