﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mondays.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Κατηγορία")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
