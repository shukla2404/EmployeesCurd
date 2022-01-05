using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesCurd.Models.ViewModel
{
    public class UpdateEmployeeModel
    {
        public int Id { get; set; }

        public string EName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }
        public string Image { get; set; }

        public decimal Salary { get; set; }

        public String Address { get; set; }
        public String BranchId { get; set; }

    }
}
