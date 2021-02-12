using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinBarCode.DAL.DataModel
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(24)]
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }

    }
}
