using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mondays.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Επωνυμία")]
        public string Name { get; set; }
        [Display(Name = "Διεύθυνση")]
        public string StreetAddress { get; set; }
        [Display(Name = "Πόλη")]
        public string City { get; set; }
        [Display(Name = "Νομός")]
        public string State { get; set; }
        [Display(Name = "Ταχ. Κωδικός")]
        public string PostalCode { get; set; }
        [Display(Name = "Τηλέφωνο")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Εξουσιοδοτημένη")]
        public bool IsAuthorizedCompany { get; set; }
    }
}
