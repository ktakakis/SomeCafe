using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mondays.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public OrderHeader OrderHeader { get; set; }
        [Required]
        [Display(Name = "Προϊόν")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [Display(Name = "Προϊόν")]
        public Product Product { get; set; }
        [Display(Name = "Ποσότητα")]
        public int Count { get; set; }
        [Display(Name = "Τιμή")]
        public double Price { get; set; }

        [Display(Name = "Γλυκαντικό")]
        public int? SweetenerId { get; set; }

        [Display(Name = "Γλυκαντικό")]
        [ForeignKey("SweetenerId")]
        public Sweeteners Sweetener { get; set; }

        [Display(Name = "Γλυκύτητα")]
        public int? SweetnessId { get; set; }

        [Display(Name = "Γλυκύτητα")]
        [ForeignKey("SweetnessId")]
        public Sweetness Sweetness { get; set; }

        [Display(Name = "Επικάλυψη")]
        public int? ToppingId { get; set; }

        [Display(Name = "Επικάλυψη")]
        [ForeignKey("ToppingId")]
        public Topping Topping { get; set; }

        [Display(Name = "Γάλα")]
        public int? MilkTypeId { get; set; }

        [Display(Name = "Γάλα")]
        [ForeignKey("MilkTypeId")]
        public MilkType MilkTypes { get; set; }

        [Display(Name = "Πάγος")]
        public int? IceCubeId { get; set; }

        [Display(Name = "Πάγος")]
        [ForeignKey("IceCubeId")]
        public IceCube IceCubes { get; set; }

        [Display(Name = "Ποικιλία")]
        public int? OriginId { get; set; }

        [Display(Name = "Ποικιλία")]
        [ForeignKey("OriginId")]
        public Origin Origins { get; set; }


    }
}
