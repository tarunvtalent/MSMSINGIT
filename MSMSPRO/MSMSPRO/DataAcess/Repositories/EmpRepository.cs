using Microsoft.EntityFrameworkCore;
using MSMSPRO.DataAcess.IRepositories;
using MSMSPRO.DBContext;
using MSMSPRO.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSMSPRO.DataAcess.Repositories
{
    public class EmpRepository : IEmpRepository
    {
        public MsmsDBContext Ms;

        public EmpRepository(MsmsDBContext _ms)
        {
            this.Ms = _ms;
        }
        public async Task<int> DeleteEmployee(int empid)
        {
            var EmpId1 = Ms.Employees.Find(empid);
            Ms.Employees.Remove(EmpId1);
            return await Ms.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await Ms.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeebydeptno(int dpno)
        {
            return await Ms.Employees.Where(x=> x.Dpno == dpno).ToListAsync();
        }

        public async Task<Employee> GetEmployeeByEmail(string Email)
        {
            return await Ms.Employees.Where(x => x.Email == Email).SingleOrDefaultAsync(); 
        }

        public async Task<bool> Getemployeebyemailandgivestatus(string email)
        {
            var empexits = await Ms.Employees.FirstOrDefaultAsync(x => x.Email == email);
            return (empexits.active );
        }

        public async Task<Employee> GetEmployeeByEmailanpaassword(string Email, string password)
        {

            return await Ms.Employees.Where(x => x.Email == Email && x.Password == password).SingleOrDefaultAsync();

        }

        public async Task<bool> Getemployeebygmailandpasswordreturnsboolean(string email, string password)
        {
            bool employeeexits = await Ms.Employees.AnyAsync(x => x.Email == email && x.Password == password);
            return employeeexits;
        }

        public async Task<List<Employee>> GetEmployeesbydeptno(int dpno)
        {
            return await Ms.Employees.Where(x=>x.Dpno == dpno).ToListAsync();
        }

        public async Task<Employee> GetEmployeesbyEmpid(int Empid)
        {
            return await Ms.Employees.FindAsync(Empid);
        }

        public async Task<int> Insertemployee(Employee emp)
        {
            await Ms.Employees.AddAsync(emp);
            return await Ms.SaveChangesAsync();
        }

       

        public async Task<int> UpdateEmployee(Employee emp)
        {
            Ms.Employees.Update(emp);
            return await Ms.SaveChangesAsync();
        }

    }

}

