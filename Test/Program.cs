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

            #region Comented code

            /*string dateDay = DateTime.Now.ToString("dd");
            string dateMonth = DateTime.Now.ToString("MM");
            string dateYear = DateTime.Now.ToString("yyyy");

            int year = Convert.ToInt32(dateYear);



            using (BarCodeContext context = new BarCodeContext())
            {
                EncryptedDate eDate = new EncryptedDate();

                var Jan = context.EncryptedDates.Find(year)?.Jan;
                var Feb = context.EncryptedDates.Find(year)?.Feb;
                var Mar = context.EncryptedDates.Find(year)?.Mar;
                var Apr = context.EncryptedDates.Find(year)?.Apr;
                var May = context.EncryptedDates.Find(year)?.May;
                var Jun = context.EncryptedDates.Find(year)?.Jun;
                var Jul = context.EncryptedDates.Find(year)?.Jul;
                var Aug = context.EncryptedDates.Find(year)?.Aug;
                var Sep = context.EncryptedDates.Find(year)?.Sep;
                var Oct = context.EncryptedDates.Find(year)?.Oct;
                var Nov = context.EncryptedDates.Find(year)?.Nov;
                var Dec = context.EncryptedDates.Find(year)?.Dec;

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
                };

                Console.WriteLine($"{monthList[dateMonth]}{dateDay}0000");

                /*FileInfo fi = new FileInfo(@"C:\Users\Dante\Documents\PrinBarCode\Test\InicializationFile\Inicial.xlsx");
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet firstWorksheet = excelPackage.Workbook.Worksheets[0];
                    ExcelWorksheet namedWorksheet = excelPackage.Workbook.Worksheets["SomeWorksheet"];

                    ExcelWorksheet anotherWorksheet =
                        excelPackage.Workbook.Worksheets.FirstOrDefault(x => x.Name == "SomeWorksheet");
                    for (int i = 3; i < 48; i++)
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
                    }
                }
            }*/
            

            #endregion


            string date = DateTime.Now.ToString("dd.MM.yyyy");

            Program pS = new Program();
            string[] dateSplit = pS.Split(date);
            string day = dateSplit[0], month = dateSplit[1], year = dateSplit[2];

            Console.WriteLine("Готово!");
            Console.ReadKey();
        }

        public string[] Split(string date)
        {
            string[] s = date.Split('.');
            string[] arrDate = new string[3];
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    arrDate[0] = s[0];
                }
                else if (i == 1)
                    arrDate[1] = s[1];
                else if (i == 2)
                    arrDate[2] = s[2];
            }
            

            return arrDate;
        }
    }
}
