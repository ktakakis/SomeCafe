using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mondays.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Όνομα")]
        public string Name { get; set; }

        [Display(Name = "Διεύθυνση")]
        public string StreetAddress { get; set; }

        [Display(Name = "Πόλη")]
        public string City { get; set; }

        [Display(Name = "Νομός")]
        public string State { get; set; }

        [Display(Name = "Ταχ. Κωδικός")]
        public string PostalCode { get; set; }

        [Display(Name = "Εταιρία")]
        public int? CompanyId { get; set; }

        [Display(Name = "Εταιρία")]
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        [Display(Name = "Ρόλος")]
        [NotMapped]
        public string Role { get; set; }
    }
}
