using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

///View model for Merge the two table///

namespace EmployeesCurd.Models.ViewModel
{
    public class EmployeeBranchModel
    {
        public List<Employee> Employees { get; set; }
        public List<Branch> Branches { get; set; }
    }
}
