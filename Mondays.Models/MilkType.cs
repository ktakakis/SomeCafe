using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mondays.Models
{
    public class MilkType 
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Τύπος Γάλακτος")]
        [Required]
        [MaxLength(50)]
        public string MilkTypeName { get; set; }
    } 
}
