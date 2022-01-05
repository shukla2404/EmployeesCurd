using EmployeesCurd.Models;
using EmployeesCurd.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesCurd.Repository
{
   public interface IEmployee
    {
        List<Employee> GetEmployees();
        CreateBranch PostEmployee(CreateBranch employee);

        Employee DeleteEmployee(int id);

        Employee update(int id);
        Employee UpdateEmployee(CreateBranch employee);

        bool UpdateStatus(int id);

        Employee GetEmployeeById(int id);

        List<Branch> GetBranches();

        Branch CreateBranch(Branch Cb);

        List<EmployeeViewModel> GetEmployeeViewModels();

        List<Employee> GetEmployeeByBranch(int id);

    }
}
