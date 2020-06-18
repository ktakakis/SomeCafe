using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mondays.Models
{
    public class Sweetness 
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Γλυκύτητα")]
        [Required]
        [MaxLength(50)]
        public string SweetnessName { get; set; }
        
        [Display(Name = "Βάρος (γρ.)")]
        public int Weight { get; set; }
    }
}
