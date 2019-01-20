using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Models;

namespace ZooDb.ViewModels
{
    public class AnimalByType
    {
     
        public string CurrentType { get; set; }
        public List<Animal> Animals { get; set; }
       public  AnimalType _AnimalTypes { get; set; }
     
        
    }
}
