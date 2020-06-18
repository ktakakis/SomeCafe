using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mondays.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Τίτλος")]
        public string Title { get; set; }
        [Display(Name = "Περιγραφή")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Κωδικός Προϊόντος")]
        public string ProductCode { get; set; }
        [Required]
        [Display(Name = "Προμηθευτής")]
        public string ProductVendor { get; set; }
        [Required]        
        [Display(Name = "Τιμή καταλόγου")]
        public double ListPrice { get; set; }
        [Required]
        [Display(Name = "Τιμή")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Τιμή '50'")]
        public double Price50 { get; set; }
        [Required]
        [Display(Name = "Τιμή '100'")]
        public double Price100 { get; set; }

        [Display(Name = "Εικόνα")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Κατηγορία")]
        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        [Display(Name = "Κατηγορία")]
        public Category Category { get; set; }

        [Required]
        [Display(Name = "Υποκατηγορία")]
        public int CoverTypeId { get; set; }

        [NotMapped]
        public Boolean IsPrefer { get; set; }

        [ForeignKey("CoverTypeId")]
        [Display(Name = "Υποκατηγορία")]
        public CoverType CoverType { get; set; }
    }
}
