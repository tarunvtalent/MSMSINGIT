using Microsoft.EntityFrameworkCore;
using MSMSPRO.Models;

namespace MSMSPRO.DBContext
{
    public class MsmsDBContext : DbContext
    {

        public MsmsDBContext(DbContextOptions<MsmsDBContext>options) : base(options) { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
