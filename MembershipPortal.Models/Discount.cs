using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.Models
{
    [Table("Discounts")]
    public class Discount
    {
        [Required(ErrorMessage = "Discount Id is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required(ErrorMessage = "Discount Code is required")]
        [MaxLength(10, ErrorMessage = "Discount code cannot be greater than length 10")]
        public string DiscountCode { get; set; }
        [Required(ErrorMessage = "Discount Amount is required")]
        
        public decimal DiscountAmount { get; set; }
        [Required(ErrorMessage = "DiscountModeId is required")]
        //[ForeignKey(nameof(DiscountMode))]
        //public long DiscountModeId { get; set; }
        //public virtual DiscountMode DiscountMode { get; set; }
        public bool IsDiscountInPercentage { get; set; } = false;

    }
}
