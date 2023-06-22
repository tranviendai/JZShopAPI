using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JZeno.Models
{
    public class ProductColor
    {
        [Key]
        public int Id { get; set; }
        [StringLength(16)]
        public string? Name { get; set; }

        public List<ProductSize>? ProductSize { get; set; } = new List<ProductSize>();

        [ForeignKey("Id")]
        public string? ProductID { get; set; }
        
    }
}
