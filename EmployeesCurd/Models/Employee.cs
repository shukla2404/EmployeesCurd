using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesCurd.Models
{
    public class Employee
    {
        //Primary Key 
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Enter Employee Name")]
        public string EName { get; set; }

        [Required]
        [Display(Name = "Enter Employee EmailId")]
        public string Email { get; set; }

        public string Gender { get; set; }
        public string Image { get; set; }

        [Required]
        [Display(Name = "Enter Employee Salary")]
        public decimal Salary { get; set; }

        public String Address { get; set; }

        public bool IsActive { get; set; }

        public Branch Branch { get; set; }
        

    }
}
