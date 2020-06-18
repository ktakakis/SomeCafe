using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mondays.Models
{
    public class Sweeteners
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Γλυκαντικά")]
        [Required]
        [MaxLength(50)]
        public string SweetenerName { get; set; }
    }
}
