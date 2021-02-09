using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class DateCodes : IEquatable<DateCodes>
    {
        public string Year { get; set; }
        public string Month { get; set; }


        public bool Equals(DateCodes other)
        {
            throw new NotImplementedException();
        }
    }
}
