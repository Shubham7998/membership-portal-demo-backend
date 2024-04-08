using System.ComponentModel.DataAnnotations;

namespace MembershipPortal.DTOs
{
    public record CreateDiscountDTO(
             [Required(ErrorMessage = "Discount Code is required")] string DiscountCode,
             [Required(ErrorMessage = "Discount Amount is required")] decimal DiscountAmount,
             bool IsDiscountInPercentage
        );
    public record UpdateDiscountDTO(
             [Required(ErrorMessage = "Discount Id is required")] long Id,
             [Required(ErrorMessage = "Discount Code is required")] string DiscountCode,
             [Required(ErrorMessage = "Discount Amount is required")]
             [Range(0.01, double.MaxValue, ErrorMessage = "Discount Amount must be greater than zero")]
             decimal DiscountAmount,
             bool IsDiscountInPercentage
        );
    public record GetDiscountDTO(
             long Id,
             string DiscountCode,
             decimal DiscountAmount,
             bool IsDiscountInPercentage
        );
}
