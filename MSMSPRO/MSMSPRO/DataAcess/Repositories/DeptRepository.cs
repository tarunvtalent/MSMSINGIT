using Microsoft.EntityFrameworkCore;
using MSMSPRO.DataAcess.IRepositories;
using MSMSPRO.DBContext;
using MSMSPRO.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace MSMSPRO.DataAcess.Repositories
{
    public class DeptRepository : IDeptRepository
    {
        public MsmsDBContext Ms;

        public DeptRepository(MsmsDBContext _ms)
        {
            this.Ms = _ms;    
        }
        public async Task<List<Department>> Alldepartments()
        {
            return await Ms.Departments.ToListAsync();
        }

        public async Task<int> Insertdepartment(Department dept)
        {
            await Ms.Departments.AddAsync(dept);
            return await Ms.SaveChangesAsync();
        }
    }
}
