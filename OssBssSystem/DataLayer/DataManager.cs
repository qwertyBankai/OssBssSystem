using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OssBssSystem.DataLayer
{
    public class DataManager : DbContext
    {
        public DataManager() : base("ConnectionString")
        {
           
        }
        public DbSet<RoleOfStaff> RolesOfStaff { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
