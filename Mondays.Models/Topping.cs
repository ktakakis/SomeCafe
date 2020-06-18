using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mondays.Models
{
    public class Topping
    {
        [Key]
        public int Id { get; set; }

        [Display(Name= "Επικάλυψη")]
        [Required]
        [MaxLength(50)]
        public string ToppingName { get; set; } 
    } 
}
