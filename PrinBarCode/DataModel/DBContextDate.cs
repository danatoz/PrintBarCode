using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrinBarCode.DAL;
using PrinBarCode.DAL.DataModel;

namespace PrinBarCode.DataModel
{
    public class DBContextDate
    {
        /// <summary>
        /// Получаем в качестве аргумента дату из ui, проверяем меньше 2014 или больше 2059 года, стучимся в базу за данными о зашифрованной дате
        /// на выходе получаем зашифрованную дату по Bosch-Norm N41A_A4 вида MYY DD 0000
        /// Где MYY будет зашифрованый месяц и год полученный из бд, а DD день месяца последние 4 цифры нули.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string GetEncryptedDate(string day, string month, string year)
        {
            var yearInt = Convert.ToInt32(year);
            if (yearInt < 2014 || yearInt > 2059)
            {
                return $"{day}.{month}.{year}";
            }
            using (BarCodeContext context = new BarCodeContext())
            {
                var yearInt32 = Convert.ToInt32(year);

                var Jan = context.EncryptedDates.Find(yearInt32)?.Jan;
                var Feb = context.EncryptedDates.Find(yearInt32)?.Feb;
                var Mar = context.EncryptedDates.Find(yearInt32)?.Mar;
                var Apr = context.EncryptedDates.Find(yearInt32)?.Apr;
                var May = context.EncryptedDates.Find(yearInt32)?.May;
                var Jun = context.EncryptedDates.Find(yearInt32)?.Jun;
                var Jul = context.EncryptedDates.Find(yearInt32)?.Jul;
                var Aug = context.EncryptedDates.Find(yearInt32)?.Aug;
                var Sep = context.EncryptedDates.Find(yearInt32)?.Sep;
                var Oct = context.EncryptedDates.Find(yearInt32)?.Oct;
                var Nov = context.EncryptedDates.Find(yearInt32)?.Nov;
                var Dec = context.EncryptedDates.Find(yearInt32)?.Dec;

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
                return $"{monthList[month]}{day}0000";
            }

        }
    }
}
