using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Models;

namespace ZooDb.ViewModels
{
    public class AnimalDetailsViewModel
    {
        public int Id { get; set; }
        public string AnimalName { get; set; }
        public string AnimalType { get; set; }
        public string AnimalSex { get; set; }
        public string AnimalGrowth { get; set; }
        public string AnimalWeight { get; set; }
        public int AnimalAge { get; set; }
        public DateTime AnimalBirthday { get; set; }
        
        public Employee _Employee { get; set; }
        public AnimalType _AnimalType { get; set; }
        public Aviary _Aviary { get; set; }
        public Zoo _Zoo { get; set; }
        
    }
}
