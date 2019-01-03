using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Models;

namespace ZooDb.ViewModels
{
    public class ZooViewModel
    {
        public int Id { get; set; }
        public string ZooName { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Animal> Animals { get; set; }
        //public List<Zoo> Zoos { get; set; }
    }
}
