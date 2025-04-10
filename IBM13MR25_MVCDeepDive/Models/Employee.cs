using System.ComponentModel.DataAnnotations;

namespace IBM13MR25_MVCDeepDive.Models
{
    public class Employee
    {
        [Display(Name = "Employee ID")]
        public int EmpID { get; set; }


        [Display(Name = "Full Name")]
        // [DataType(DataType.MultilineText)]
        [Required]
        public string EmpName
        { get; set; }
        [Display(Name = "Net Salary")]

        [Range(10000, 1000000)]
        public double Salary { get; set; }

    }
}