using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.DTOs
{
    public  class UsersDTO
    {
        public record CreateUsersDto (

            string FirstName,
            string LastName,
             [Required(ErrorMessage ="Email is Requried")]
            string Email,
            [Required(ErrorMessage = "Password is Requried")]
            string Password,
            string ContactNumber
            );

        public record UpdateUsersDto(

            long Id,
            string FirstName,
            string LastName,
            [Required(ErrorMessage ="Email is Requried")]
            string Email,
            [Required(ErrorMessage = "Password is Requried")]
            string Password,
            string ContactNumber
            );

        public record GetUsersDto(
             long Id,
            string FirstName,
            string LastName,
            [Required(ErrorMessage ="Email is Requried")]
            string Email,
            [Required(ErrorMessage = "Password is Requried")]
            string Password,
            string ContactNumber

            );

    }
}
