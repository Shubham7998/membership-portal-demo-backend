using System.ComponentModel.DataAnnotations;

namespace MembershipPortal.DTOs
{
    public record CreateDiscountDTO(
             [Required(ErrorMessage = "Discount Code is required")] string DiscountCode,
             [Required(ErrorMessage = "Discount Amount is required")] decimal DiscountAmount,
             [Required(ErrorMessage = "DiscountModeId is required")] long DiscountModeId
        );
    public record UpdateDiscountDTO(
             [Required(ErrorMessage = "Discount Id is required")] long Id,
             [Required(ErrorMessage = "Discount Code is required")] string DiscountCode,
             [Required(ErrorMessage = "Discount Amount is required")] decimal DiscountAmount,
             [Required(ErrorMessage = "DiscountModeId is required")] long DiscountModeId
        );
    public record GetDiscountDTO(
             long Id,
             string DiscountCode,
             decimal DiscountAmount,
             long DiscountModeId
        );
}
