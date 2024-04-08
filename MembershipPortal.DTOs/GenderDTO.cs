using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MembershipPortal.DTOs
{
    public record CreateGenderDTO(
                            [Required(ErrorMessage = "Please enter Gender")] [MaxLength(10)] string GenderName
            );


    //DbContext 
    public record UpdateGenderDTO(
                            [Required(ErrorMessage = "Please enter Gender id")]  long Id,
                            [Required(ErrorMessage = "Please enter Gender")][MaxLength(10)] string GenderName
            );

    public record GetGenderDTO(
                            long Id,
                            string GenderName
            );



}