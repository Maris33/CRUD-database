using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZooDb.Models
{
    public class Zoo
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Hey, please provide a name!")]
        [StringLength(100, ErrorMessage = "The name is too long.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Hey, please provide an address!")]
        public string Address { get; set; }
        [Display(Name = "Founding year")]
        public DateTime FoundingYear { get; set; }
       

        //Relations

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
        
    }
}
