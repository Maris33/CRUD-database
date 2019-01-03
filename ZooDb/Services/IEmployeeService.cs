﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Models;
using ZooDb.ViewModels;

namespace ZooDb.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        Employee GetSingleEmployeeById(int id);
        void UpdateEmployee(Employee newEmployee);
        //void DeleteEmployee(int id);
        EmployeeDetailsViewModel EmployeeDetails(int id);
        /*EmployeeViewModel EmployeeDeletionConfirmation(int id);
        EmployeeViewModel EmployeeDetails(int id);*/
    }
}
