using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mondays.Models
{
    public class Origin
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ποικιλία")]
        [Required]
        [MaxLength(50)]
        public string OriginName { get; set; }
    }
}
