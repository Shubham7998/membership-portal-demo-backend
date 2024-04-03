using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MembershipPortal.DTOs
{
    public record CreateGenderDTO(
                            [Required(ErrorMessage = "Please enter Gender")] [MaxLength(10)] string GenderName
            );

    public record UpdateGenderDTO(
                            long Id,
                            [Required(ErrorMessage = "Please enter Gender")][MaxLength(10)] string GenderName
            );

    public record GetGenderDTO(
                            long Id,
                            string GenderName
            );



}