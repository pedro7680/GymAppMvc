using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymApp.Models
{
   public class Exercise
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Exercise Name")]
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }

        
    }
}
