using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSMSPRO.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Dpno { get; set; }
        public string Dname {  get; set; }  
        public string location { get; set; }   

        public ICollection<Employee> Employees { get; set; }
    }
}
