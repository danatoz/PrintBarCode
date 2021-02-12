using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinBarCode.DAL.DataModel
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public Role()
        {
            Employees = new List<Employee>();
        }
    }
}
