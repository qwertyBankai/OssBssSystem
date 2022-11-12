using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OssBssSystem.DataLayer
{
    public class Staff
    {
        
        public int Id { get; set; }
        public int Number { get; set; }
        public string Password { get; set; }
        public string Fio { get; set; }
        public RoleOfStaff RoleId { get; set; }
    }
}
