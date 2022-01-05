using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Use for input the data using second table into first table through view.
/// </summary>

namespace EmployeesCurd.Models.ViewModel
{
    public class CreateBranch
    {
        [Required]
        [Display(Name = "Enter Employee Name")]
        public string EName { get; set; }

        [Required]
        [Display(Name = "Enter Employee Email Id")]
        public string Email { get; set; }


        public string Gender { get; set; }

        [Required]
        [Display(Name = "Select Employee Image")]
        public IFormFile Image { get; set; }

        [Required]
        [Display(Name = "Enter Employee Salary")]

        public decimal Salary { get; set; }

        [Required]
        [Display(Name = "Enter Employee Complete Address")]

        public string Address { get; set; }

        public int BranchId { get; set; } 
    }
}
