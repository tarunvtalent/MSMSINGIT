using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSMSPRO.DataAcess.IRepositories;
using MSMSPRO.Models;
using System.Threading.Tasks;

namespace MSMSPRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptWebApiController : ControllerBase
    {

        public IDeptRepository IDeptRep;
        public DeptWebApiController(IDeptRepository _IDept)
        {
            this.IDeptRep = _IDept;
        }

        [Route("Alldepartments")]
        [HttpGet]
        public async Task<IActionResult> Alldepartments()
        {
            
            var Deptlist = await IDeptRep.Alldepartments();
            if(Deptlist != null)
            {
                return Ok(Deptlist);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("InsertDepartment")]
        [HttpPost]
        public async Task<IActionResult> InsertDepartmennt([FromBody] Department Dept)
        {
            var count = await IDeptRep.Insertdepartment(Dept);
            return Ok (count + "Record Inserted Successfully");
        }

    }
}
