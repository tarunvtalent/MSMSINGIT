using MSMSPRO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSMSPRO.DataAcess.IRepositories
{
    public interface IEmpRepository
    {
        public Task<List<Employee>> GetAllEmployees();
        public Task<int> Insertemployee(Employee emp);
        public Task<Employee> GetEmployeeByEmail(string Email);
        Task<Employee> GetEmployeeByEmailanpaassword(string Email, string Password);
        public Task<int> UpdateEmployee(Employee emp);
   
        public Task<int> DeleteEmployee(int empid);
        public Task<List<Employee>> GetEmployeesbydeptno(int dpno);
        public Task<Employee> GetEmployeesbyEmpid(int Empid);
        public Task<bool> Getemployeebygmailandpasswordreturnsboolean(string email ,string password);
        public Task<bool> Getemployeebyemailandgivestatus(string email);
    }
}
