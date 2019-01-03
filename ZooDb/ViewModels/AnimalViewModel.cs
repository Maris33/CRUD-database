using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooDb.ViewModels
{
    public class AnimalViewModel
    {
        public int Id { get; set; }
        public string AnimalFullName { get; set; }
        public object AnimalName { get; internal set; }
    }
}
