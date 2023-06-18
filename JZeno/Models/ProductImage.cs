using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JZeno.Models
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }

        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        public string? Image { get; set; }

        [ForeignKey("Id")]
        public string? ProductID { get; set; }
        public Product? Product { get; set; }

    }
}
