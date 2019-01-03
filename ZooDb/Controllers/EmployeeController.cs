using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZooDb.Models;
using ZooDb.Services;

namespace ZooDb.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        private IZooService _zooService;
        public EmployeeController(IEmployeeService employeeService, IZooService zooService)
        {
            _employeeService = employeeService;
            _zooService = zooService;

        }

        public IActionResult AllEmployees()
        {
            return View(_employeeService.GetAllEmployees());
        }

        public IActionResult CreateEmployee()
        {
            ViewBag.Zoos = _zooService.GetAllZoos();
            return View();
        }
        public IActionResult EmployeeCreated(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                ViewBag.Zoos = _zooService.GetAllZoos();
                return View("CreateEmployee");
            }
            _employeeService.AddEmployee(employee);
            return View();
        }
        public IActionResult EditEmployee(int id)
        {
            ViewBag.Zoos = _zooService.GetAllZoos();
            return View(_employeeService.GetSingleEmployeeById(id));
        }
        public IActionResult EmployeeEdited(Employee newEmployee)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                ViewBag.Zoos = _zooService.GetAllZoos();
                return View("EditEmployee", newEmployee);
            }
            _employeeService.UpdateEmployee(newEmployee);
            return View();

        }
        public IActionResult EmployeeDetails(int id)
        {
            return View(_employeeService.EmployeeDetails(id));
        }
    }
}
