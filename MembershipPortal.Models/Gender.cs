using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MembershipPortal.Models
{
    [Table("Genders")]
    public class Gender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        [Required(ErrorMessage = "Please enter Gender")]
        [MaxLength(10)]
        public string GenderName { get; set; }

    }
}
