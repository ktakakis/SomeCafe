using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mondays.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Ημερομηνία Παραγγελίας")]
        public DateTime OrderDate { get; set; }
        [Required]
        [Display(Name = "Ημερομηνία Παραλαβής")]
        public DateTime ShippingDate { get; set; }
        [Required]
        [Display(Name = "Σύνολο Παραγγελίας")]
        public Double OrderTotal { get; set; }
        [Display(Name = "Αριθμός Παρακολούθησης")]
        public string TrackingNumber { get; set; }
        [Display(Name = "Μεταφορέας")]
        public string Carrier { get; set; }
        [Display(Name = "Κατάσταση Παραγγελίας")]
        public string OrderStatus { get; set; }
        [Display(Name = "Κατάσταση Πληρωμής")]
        public string PaymentStatus { get; set; }
        [Display(Name = "Ημερομηνία Πληρωμής")]
        public DateTime PaymentDate { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime PaymentDueDate { get; set; }
        public string TransactionId { get; set; }
        [Display(Name = "Τηλέφωνο")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Διεύθυνση")]
        public string StreetAddress { get; set; }
        [Display(Name = "Πόλη")]
        public string City { get; set; }
        [Display(Name = "Νομός")]
        public string State { get; set; }
        [Display(Name = "Ταχ. Κωδικός")]
        public string PostalCode { get; set; }
        [Display(Name = "Όνομα")]
        public string Name { get; set; }


    }
}
