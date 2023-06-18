using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JZeno.Models
{
    public class User : IdentityUser
    {
        [StringLength(42)]
        public string? FullName { get; set; }

        [StringLength(74)]
        public string Address { get; set; }

        [StringLength(int.MaxValue)]
        public string? Image { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/M/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/M/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [StringLength(20)] //loại người dùng (VIP,Prenium,Member)
        public string? Type { get; set; }

    }
}
