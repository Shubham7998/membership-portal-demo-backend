using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.Models
{
    [Table("Subscriptions")]
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public long SubscriberId { get; set; }

        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal Discount { get; set; }

        public string CurrentDate { get; set; }

        public string ExpiryDate { get; set; }

        public decimal PriceAfterDiscount { get; set; }

        public decimal CGST { get; set; }

        public decimal SGST { get; set; }

        public decimal TotalTax { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal FinalAmount { get; set; }

    }
}
