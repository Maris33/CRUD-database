using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Data;
using ZooDb.Models;
using ZooDb.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ZooDb.Services
{
    public class EmployeeService : IEmployeeService
    {
        private ZooContext _context;
        private IHostingEnvironment _hostingEnvironment;
        
        public EmployeeService(ZooContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public void AddEmployee(Employee employee)
        {
            
            _context.Employees.Add(employee);
            _context.SaveChanges();
           
        }

        

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = _context.Employees.Include(n => n.Zoo).Include(o => o.Animals).ToList();
            return employees;
        }

        public Employee GetSingleEmployeeById(int id) => _context.Employees.Where(n => n.Id == id).FirstOrDefault();
       
        //public List<Animal> GetAnimalsByEmployeeId(int employeeId) => _context.Animals.Where(x => x.EmployeeId == employeeId).ToList();

        public void UpdateEmployee(Employee newEmployee)
        {
            Employee oldEmployee = GetSingleEmployeeById(newEmployee.Id);
            oldEmployee.FullName = newEmployee.FullName;
            oldEmployee.MaleFemale = newEmployee.MaleFemale;
            oldEmployee.Age = newEmployee.Age;
            oldEmployee.Experience = newEmployee.Experience;
            oldEmployee.PhoneNumber = newEmployee.PhoneNumber;
            oldEmployee.ZooId = newEmployee.ZooId;
            
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee employeeToBeDeleted = GetSingleEmployeeById(id);
            _context.Employees.Remove(employeeToBeDeleted);
            _context.SaveChanges();
        }

        public EmployeeViewModel EmployeeDeletionConfirmation(int id)
        {

            Employee employee = GetSingleEmployeeById(id);
            EmployeeViewModel employeeVM = new EmployeeViewModel()
            {
                Id = employee.Id,
                EmployeeName = employee.FullName
            };

            return employeeVM;

        }

       

        public EmployeeDetailsViewModel EmployeeDetails(int id)
        {
            Employee employee = GetSingleEmployeeById(id);
            EmployeeDetailsViewModel employeeVM = new EmployeeDetailsViewModel()
            {
                Id = employee.Id,
                FullEmployeeName = employee.FullName,
                EmployeeSex = employee.MaleFemale,
                EmployeeAge = employee.Age,
                EmpExperience = employee.Experience,
                EmpPhoneNumber = employee.PhoneNumber,
                _Zoo = new ZooService(_context).GetSingleZooById(employee.ZooId),
                _Animal = new AnimalService(_context, _hostingEnvironment).GetAnimalsByEmployeeId(employee.Id),
                Image = "/images/employees/" + employee.Id+ ".jpg"
            };
            return employeeVM;
        }
    }
}
