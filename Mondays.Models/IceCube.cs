using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mondays.Models
{
    public class IceCube
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Παγάκια")]
        [Required]
        [MaxLength(50)]
        public string IceCubeName { get; set; }
    }
}
