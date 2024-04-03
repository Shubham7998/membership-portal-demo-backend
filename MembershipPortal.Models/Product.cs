using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.Models
{
    [Table("Products")]
    public  class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long Id { get; set; }

        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is Requried")]
        public decimal Price { get; set; }


    }
}
