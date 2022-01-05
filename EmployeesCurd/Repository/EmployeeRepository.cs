using EmployeesCurd.Models;
using EmployeesCurd.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesCurd.Repository
{
    public class EmployeeRepository: IEmployee
    {
        private ApplicationContext Context;

        public IHostingEnvironment environment { get; }

        public EmployeeRepository
            (ApplicationContext _context,IHostingEnvironment _environment)
        {
            Context = _context;
            environment = _environment;
        }

        public List<Employee> GetEmployees()
        {
            var employees = Context.Employees.Where(e=>e.IsActive==true).ToList();
            return(employees) ;
        }

        public CreateBranch PostEmployee(CreateBranch employee)
        {
            ///Image uploadation and path Decleartion process Start

            string path = environment.WebRootPath;
            string fullPath = Path.Combine(path, "image", employee.Image.FileName);
            FileStream stream = new FileStream(fullPath,FileMode.Create);
            employee.Image.CopyTo(stream);

            string dbPath = Path.Combine("image", employee.Image.FileName);

            ///Image path Decleartion process End
            

            var Brnch = Context.Branches.SingleOrDefault(e=>e.Id == employee.BranchId) ;

            var emp = new Employee()
            {
                EName = employee.EName,
                Email = employee.Email,
                Gender = employee.Gender,
                Image = dbPath,
                Salary = employee.Salary,
                Address = employee.Address,
                IsActive = true,
                Branch = Brnch
            };
            Context.Employees.Add(emp);
            Context.SaveChanges();
            return employee;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = Context.Employees.SingleOrDefault(e => e.Id == id && e.IsActive == true);
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            var pro = Context.Employees.SingleOrDefault(e => e.Id == id);
            if(pro != null)
            {
                Context.Employees.Remove(pro);
                Context.SaveChanges();
                return pro;
            }
            return null;
        }

        public Employee update(int id)
        {
            var pro = Context.Employees.SingleOrDefault(e => e.Id == id);
            if (pro != null)
            {
                return pro;
            }
            return null;
        }


        public Employee UpdateEmployee(CreateBranch employee)
        {
            var Brnch = Context.Branches.SingleOrDefault(e => e.Id == employee.BranchId);
            var emp = new Employee()
            {
                EName = employee.EName,
                Email = employee.Email,
                Gender = employee.Gender,
                Salary = employee.Salary,
                Address = employee.Address,
                IsActive = true,
                Branch = Brnch
            };
            Context.Employees.Update(emp);
            Context.SaveChanges();
            return emp;
        }

        public bool UpdateStatus(int id)
        {
            var employee = Context.Employees.SingleOrDefault(e => e.Id == id);
                if (employee != null)
                {
                    employee.IsActive = false;
                    Context.Employees.Update(employee);
                    Context.SaveChanges();
                return true;
                }
            return false;
        }


        public Branch CreateBranch(Branch cb)
        {
            Context.Branches.Add(cb);
            Context.SaveChanges();
            return cb;
        }

        public List<Branch> GetBranches()
        {
            return Context.Branches.ToList();
        }

        public List<EmployeeViewModel> GetEmployeeViewModels()
        {
            var Emps = from empl in Context.Employees   //First table
                       join
                       brnch in Context.Branches        //Second table
                       on empl.Branch.Id equals brnch.Id  //Condition
                       where empl.IsActive == true        // where Condition
                       select new EmployeeViewModel()      // New Model data that pass in view 
                       {
                           Id = empl.Id,
                           EName = empl.EName,
                           Email = empl.Email,
                           Gender = empl.Gender,
                           Image = empl.Image,
                           Salary = empl.Salary,
                           Address = empl.Address,
                           IsActive = empl.IsActive,
                           BranchName = brnch.BranchName,
                           Description = brnch.Description
                       };
            return Emps.ToList();
        }

       public List<Employee> GetEmployeeByBranch(int id)
        {
            var Empls = Context.Employees.Where(e => e.Branch.Id == id).ToList();
            return Empls;
        }
    }
}
