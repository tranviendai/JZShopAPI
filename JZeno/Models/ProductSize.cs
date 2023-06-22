using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JZeno.Models
{
    public class ProductSize
    {
        [Key]
        public int Id { get; set; }

        [StringLength(3)]
        public string? Size { get; set; }
        public int? Quantity { get; set; }

        [ForeignKey("Id")]
        public int ColorID { get; set; }

        public ProductColor? Color { get; set; }

    }
}
