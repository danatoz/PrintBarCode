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
            string dateDay = DateTime.Now.ToString("dd");
            string dateMonth = DateTime.Now.ToString("MM");
            string dateYear = DateTime.Now.ToString("yyyy");

            Convert.ToInt32(dateYear);



            using (BarCodeContext context = new BarCodeContext())
            {
                EncryptedDate eDate = new EncryptedDate();

                /* var Jan = context.EncryptedDates.Find(2014)?.Jan;
                 var Feb = context.EncryptedDates.Find(2014)?.Feb;
                 var Mar = context.EncryptedDates.Find(2014)?.Mar;
                 var Apr = context.EncryptedDates.Find(2014)?.Apr;
                 var May = context.EncryptedDates.Find(2014)?.May;
                 var Jun = context.EncryptedDates.Find(2014)?.Jun;
                 var Jul = context.EncryptedDates.Find(2014)?.Jul;
                 var Aug = context.EncryptedDates.Find(2014)?.Aug;
                 var Sep = context.EncryptedDates.Find(2014)?.Sep;
                 var Oct = context.EncryptedDates.Find(2014)?.Oct;
                 var Nov = context.EncryptedDates.Find(2014)?.Nov;
                 var Dec = context.EncryptedDates.Find(2014)?.Dec;

                 Dictionary<string, string> monthList = new Dictionary<string, string>()
                 {
                     {"01", Jan },
                     {"02", Feb },
                     {"03", Mar },
                     {"04", Apr },
                     {"05", May },
                     {"06", Jun },
                     {"07", Jul },
                     {"08", Aug },
                     {"09", Sep },
                     {"10", Oct },
                     {"11", Nov },
                     {"12", Dec }
                 };*/

                //Console.WriteLine(monthList[dateMonth]);

                FileInfo fi = new FileInfo(@"C:\Users\Dante\Documents\PrinBarCode\Test\InicializationFile\Inicial.xlsx");
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet firstWorksheet = excelPackage.Workbook.Worksheets[0];
                    ExcelWorksheet namedWorksheet = excelPackage.Workbook.Worksheets["SomeWorksheet"];

                    ExcelWorksheet anotherWorksheet =
                        excelPackage.Workbook.Worksheets.FirstOrDefault(x => x.Name == "SomeWorksheet");
                    for (int i = 1; i < 48; i++)
                    {
                        eDate.Jan = firstWorksheet.Cells[i, 2].Value.ToString();
                        eDate.Feb = firstWorksheet.Cells[i, 3].Value.ToString();
                        eDate.Mar = firstWorksheet.Cells[i, 4].Value.ToString();
                        eDate.Apr = firstWorksheet.Cells[i, 5].Value.ToString();
                        eDate.May = firstWorksheet.Cells[i, 6].Value.ToString();
                        eDate.Jun = firstWorksheet.Cells[i, 7].Value.ToString();
                        eDate.Jul = firstWorksheet.Cells[i, 8].Value.ToString();
                        eDate.Aug = firstWorksheet.Cells[i, 9].Value.ToString();
                        eDate.Sep = firstWorksheet.Cells[i, 10].Value.ToString();
                        eDate.Oct = firstWorksheet.Cells[i, 11].Value.ToString();
                        eDate.Nov = firstWorksheet.Cells[i, 12].Value.ToString();
                        eDate.Dec = firstWorksheet.Cells[i, 13].Value.ToString();
                        context.EncryptedDates.Add(eDate);
                        context.SaveChanges();
                    }

                    /*string test;
                    for (int i = 2; i < 48; i++)
                    {
                        for (int j = 2; j < 14; j++)
                        {
                           test = firstWorksheet.Cells[i, j].Value.ToString();
                           Console.WriteLine(test);
                        }
                    }*/

                }

                //Console.WriteLine($@"{a}{dateDay}0000");
                /*eDate.EncryptedDateId = 2014;
                eDate.Jan = "417";
                eDate.Feb = "418";
                eDate.Mar = "419";
                eDate.Apr = "420";
                eDate.May = "453";
                eDate.Jun = "454";
                eDate.Jul = "455";
                eDate.Aug = "456";
                eDate.Sep = "457";
                eDate.Oct = "458";
                eDate.Nov = "459";
                eDate.Dec = "460";

                context.EncryptedDates.Add(eDate);
                context.SaveChanges();*/
            }

            Console.WriteLine("Готово!");
            Console.ReadKey();
        }
    }
}
