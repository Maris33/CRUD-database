using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooDb.Models
{
    public class Animal
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide full name!")]
        [StringLength(25, ErrorMessage = "The name is too long.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Male/Female")]
        public string MaleFemale { get; set; }
        [Display(Name = "Growth")]
        public string Growth { get; set; }
        [Display(Name = "Weight")]
        public string Weight { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        //Relations
        public virtual Zoo Zoo { get; set; }
        [Display(Name = "Zoo Name")]
        public int ZooId { get; set; }

        public virtual Employee Employee { get; set; }
        [Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }

        public virtual AnimalType AnimalType { get; set; }
        [Display(Name = "Animal Type")]
        public int AnimalTypeId { get; set; }

        public virtual Aviary Aviary { get; set; }
        [Display(Name = "Animal Aviary")]
        public int AviaryId { get; set; }

        
        
    }
}
