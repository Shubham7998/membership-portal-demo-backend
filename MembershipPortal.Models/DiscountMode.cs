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
        public bool IsDiscountInPercentage { get; set; }
    }
}
