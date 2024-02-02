using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSMSPRO.DataAcess.IRepositories;
using MSMSPRO.Filters;
using MSMSPRO.Models;
using System;
using System.Threading.Tasks;
namespace MSMSPRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [MyExceptionFilter]
    public class EmpWebApiController : ControllerBase 
    {
        public IEmpRepository IEmpRep;
        public EmpWebApiController(IEmpRepository _IEmpRep)
        {
            IEmpRep = _IEmpRep;
        }

        [Route("AllEmployees")]
        [HttpGet]
        public async Task<IActionResult> AllEmployees()
        {
            var Emplist = await IEmpRep.GetAllEmployees();
            if(Emplist != null)
            {
                return Ok(Emplist);
            }
            else
            { 
                return NotFound();
            }
        }

        [Route("InsertEmployee")]
        [HttpPost]
        public async Task<IActionResult> InsertEmployee([FromBody] Employee emp)
        {
            var count = await IEmpRep.Insertemployee(emp);
            return Ok(count + " Record Inserted Successfully ");
        }

        [Route("GetemployeebyemailpasswordReturnsbool")]
        [HttpGet]
        public async Task<IActionResult> GetemployeebyemailpasswordReturnsbool(string email,string password)
        {
            var employee = await IEmpRep.Getemployeebygmailandpasswordreturnsboolean(email, password);
            if (employee)
            {
                return Ok("True");
            }
            else
            {
                return NotFound("false");
            }
        }


        [Route("GetEmployeebyemailandpassword")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeebyemailandpassword(string email,string password)
        {
            var emp = await IEmpRep.GetEmployeeByEmailanpaassword(email, password);
            return Ok(emp);
        }

        [Route("GetEmployeebyDepartmentNo")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeebyDepartmentNo(int dpno)
        {
            var emp = await IEmpRep.GetEmployeesbydeptno(dpno);
            return Ok(emp);
        }


        [Route("GetEmployeebyEmpid")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeebyEmpid(int Empid)
        {
            var emp = await IEmpRep.GetEmployeesbyEmpid(Empid);
            return Ok(emp);

        }


        [Route("GetemployeebyemailReturnsbool")]
        [HttpGet]
        public async Task<IActionResult> GetemployeebyemailReturnsbool(string email)
        {
            var employee = await IEmpRep.Getemployeebyemailandgivestatus(email);
            
           
                return Ok(employee);
            
           
        }

        [Route("DeleteEmployee")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int empid)
        {
            var count = await IEmpRep.DeleteEmployee(empid);
            return Ok(count + "Record Deleted successfully ");
        }


        [Route("UpdateEmployees")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployees([FromBody] Employee Emp)
        {
           
            var count = await IEmpRep.UpdateEmployee(Emp);
            return Ok(count + "Record Updated Sucessfully");

        }

    }
}
