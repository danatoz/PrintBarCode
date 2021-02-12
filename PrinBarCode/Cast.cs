using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinBarCode
{
    public class Cast
    {
        /// <summary>
        /// Получаем дату вида 10.02.2021 на выходе получаем массив 10 после 02 после 2021
        /// </summary>
        /// <param name="getDate"></param>
        /// <returns></returns>
        public string[] Split(string date)
        {
            string[] arrDate = date.Split('.');

            return arrDate;
        }
    }
}
