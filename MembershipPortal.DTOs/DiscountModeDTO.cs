using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.DTOs
{
    public record CreateDiscountModeDTO(
            [Required(ErrorMessage = "Discount Mode Type is Required")]
            [MaxLength(100, ErrorMessage = "Max Length of Discount Type is 100 only")] string DiscountModeType
        );
    public record UpdateDiscountModeDTO(
            [Required(ErrorMessage = "Discount Mode Id is required")] long Id,
            [Required(ErrorMessage = "Discount Mode Type is Required")]
            [MaxLength(100, ErrorMessage = "Max Length of Discount Type is 100 only")] string DiscountModeType
        );
    public record GetDiscountModeDTO(
            long Id,
            string DiscountModeType
        );

}
