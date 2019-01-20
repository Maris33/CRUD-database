using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Models;

namespace ZooDb.ViewModels
{
    public class ZooDetailsViewModel
    {
        public int Id { get; set; }
        public string ZooName { get; set; }
        public string ZooAddress { get; set; }
        public DateTime ZooFoundingYear { get; set; }
       
        public List<Employee> Employees { get; set; }
        public List<Animal> Animals { get; set; }
        
    }
}
