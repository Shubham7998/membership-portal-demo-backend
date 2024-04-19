using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.DTOs
{
    public record CreateTaxDTO(
            [Required(ErrorMessage = "State Name is required")]
            string StateName,
            [Required(ErrorMessage = "SGST is required")]
            [Range(0.01, double.MaxValue, ErrorMessage = "SGST must be greater than zero")]
            decimal SGST,
            [Required(ErrorMessage = "CGST is required")]
            [Range(0.01, double.MaxValue, ErrorMessage = "CGST must be greater than zero")]
            decimal CGST
        );

    public record UpdateTaxDTO(

        [Required(ErrorMessage = "State Name is required")]
            string StateName,
            [Required(ErrorMessage = "Tax Id is required")] long Id,
            [Required(ErrorMessage = "SGST is required")]
            [Range(0.01, double.MaxValue, ErrorMessage = "SGST must be greater than zero")]
            decimal SGST,
            [Required(ErrorMessage = "CGST is required")]
            [Range(0.01, double.MaxValue, ErrorMessage = "CGST must be greater than zero")]
            decimal CGST
       
        );


    public record GetTaxDTO(
            long Id,
            string StateName,
            decimal SGST,
            decimal CGST,
            decimal TotalTax
        );
}
