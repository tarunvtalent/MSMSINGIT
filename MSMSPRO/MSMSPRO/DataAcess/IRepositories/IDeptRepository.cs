using MSMSPRO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSMSPRO.DataAcess.IRepositories
{
    public interface IDeptRepository
    {

        public Task<List<Department>> Alldepartments();

        public Task<int> Insertdepartment(Department dept);

    }
}
