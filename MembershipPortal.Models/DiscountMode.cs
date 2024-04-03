using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.Models
{
    [Table("DiscountModes")]
    public class DiscountMode
    {
        [Required(ErrorMessage = "Discount Mode Id is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DiscountModeId { get; set; }
        [Required(ErrorMessage = "Discount Mode Type is Required")]
        [MaxLength(100, ErrorMessage = "Max Length of Discount Type is 100 only")]
        public string DiscountModeType { get; set; }
    }
}
