using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Models;

namespace ZooDb.ViewModels
{
    public class EmployeeDetailsViewModel
    {
        public int Id { get; set; }
        public string FullEmployeeName { get; set; }
        public string EmployeeSex { get; set; }
        public int EmployeeAge { get; set; }
        public string EmpExperience { get; set; }
        public string EmpPhoneNumber { get; set; }
        public Zoo _Zoo { get; set; }
    }
}
