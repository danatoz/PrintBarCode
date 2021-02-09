using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PrinBarCode.DAL.DataModel
{
    public class EncryptedDate
    {
        [Key]
        public int EncryptedDateId { get; set; }
        [MaxLength(100)]
        public string Jan { get; set; }
        [MaxLength(100)]
        public string Feb { get; set; }
        [MaxLength(100)]
        public string Mar { get; set; }
        [MaxLength(100)]
        public string Apr { get; set; }
        [MaxLength(100)]
        public string May { get; set; }
        [MaxLength(100)]
        public string Jun { get; set; }
        [MaxLength(100)]
        public string Jul { get; set; }
        [MaxLength(100)]
        public string Aug { get; set; }
        [MaxLength(100)]
        public string Sep { get; set; }
        [MaxLength(100)]
        public string Oct { get; set; }
        [MaxLength(100)]
        public string Nov { get; set; }
        [MaxLength(100)]
        public string Dec { get; set; }



    }
}
