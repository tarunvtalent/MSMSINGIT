using MSMSPRO.CustomAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSMSPRO.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Empid {  get; set; }

        [Required (ErrorMessage ="Please enter name...!")]
        [StringLength(18,ErrorMessage ="Please Enter name in 18charectors Only ...!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please ener charectors only....! ")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter Gender....!")]
        public string Gender { get; set; }
        [Required(ErrorMessage ="Please enter Email..!")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter proper email format")]

        public string Email {  get; set; }
        [Required(ErrorMessage = "Please enter password..!")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter phone..!")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter digits only...")]

        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter Salary...! ")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter digits only...")]
        [Range(5000, 50000, ErrorMessage = "Please enter the salary in between 5000(Including)  and 50000( Including ) only ....!")]
        [SalValCheck(ErrorMessage = "Please eneter salary should be divisible by 10 only....!")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Please enter Address...! ")]

        public string Address {  get; set; }    

        public bool active {  get; set; } 

        [ForeignKey("Department")]
        public int Dpno {  get; set; }

        public Department Department { get; set; }
    }
}
