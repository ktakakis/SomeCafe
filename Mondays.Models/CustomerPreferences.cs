using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mondays.Models
{
    public class CustomerPreferences
    {
        public CustomerPreferences()
        {
        }
        [Key]
        public int Id { get; set; }

        [Display(Name = "Χρήστης")]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Είδος")]
        public int ProductId { get; set; }

        [Display(Name = "Είδος")]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Display(Name = "Γλυκαντικό")]
        public int SweetenerId { get; set; }

        [Display(Name = "Γλυκαντικό")]
        [ForeignKey("SweetenerId")]
        public Sweeteners Sweetener { get; set; }
        
        [Display(Name = "Γλυκύτητα")]
        public int SweetnessId { get; set; }
        
        [Display(Name = "Γλυκύτητα")]
        [ForeignKey("SweetnessId")]
        public Sweetness Sweetness { get; set; }

        [Display(Name = "Επικάλυψη")]
        public int ToppingId { get; set; }

        [Display(Name = "Επικάλυψη")]
        [ForeignKey("ToppingId")]
        public Topping Topping { get; set; }

        [Display(Name = "Γάλα")]
        public int MilkTypeId { get; set; }

        [Display(Name = "Γάλα")]
        [ForeignKey("MilkTypeId")]
        public MilkType MilkTypes { get; set; }

        [Display(Name = "Πάγος")]
        public int IceCubeId { get; set; }

        [Display(Name = "Πάγος")]
        [ForeignKey("IceCubeId")]
        public IceCube IceCubes { get; set; } 

        [Display(Name = "Ποικιλία")]
        public int OriginId { get; set; }

        [Display(Name = "Ποικιλία")]
        [ForeignKey("OriginId")]
        public Origin Origins { get; set; } 

        [Display(Name = "Σημειώσεις")]
        public string Notes { get; set; }

    }
}
