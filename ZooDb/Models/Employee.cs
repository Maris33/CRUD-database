using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZooDb.Models
{
    public class Employee
    {
      
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name.")]
        [DataType(DataType.Text)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string MaleFemale { get; set; }
        [Range(20, 60, ErrorMessage = "Please provide an age between 20 and 60.")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Years of experience")]
        public string Experience { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please provide a valid phone number")]
        [Phone(ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        
        // Relations
        
        public virtual Zoo Zoo { get; set; }
        [Display(Name = "Zoo Name")]
        public int ZooId { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }


    }
}
