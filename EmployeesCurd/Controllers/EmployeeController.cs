using EmployeesCurd.Models;
using EmployeesCurd.Models.ViewModel;
using EmployeesCurd.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesCurd.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployee employees;

        public EmployeeController(IEmployee employee)
        {   
            employees = employee;
        }


        public IActionResult Index()
        {
            
            //// For using Join Query to fetch  the two table data write query using linq

            var empls = employees.GetEmployeeViewModels();
            return View(empls);
        }

        public IActionResult Create()
        {
            var branch = employees.GetBranches();
            ViewBag.branch = branch;
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateBranch employee)
        {
            if (ModelState.IsValid)
            {
               employees.PostEmployee(employee);
                return RedirectToAction("Index");
            }
            else
            {
                var branch = employees.GetBranches();
                ViewBag.branch = branch;
                return View();
                return View("employee");
            }
            
        }

        public IActionResult Delete(int id)
        {
            employees.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
                return View(employees.GetEmployeeById(id)); 
        }

        [HttpPost]
        public IActionResult Update(CreateBranch employee)
        {
            employees.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateStatus(int id)
        {
            employees.UpdateStatus(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateBranch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBranch(Branch branch)
        {
            employees.CreateBranch(branch);
            return RedirectToAction("Index");
        }

        public IActionResult ShowBranch()
        {
            var branch = employees.GetBranches();
            return View(branch);
        }

        
        public IActionResult ShowEmployee(int id)
        {
            var empls = employees.GetEmployeeByBranch(id);
            return View(empls);
        }
    }
}
