using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace JZeno.Models
{
    public class Product
    {
        [Key]
        [StringLength(10)]
        public string? Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Index { get; set; }
        [StringLength(150)]
        public string? Name { get; set; }
        public DateTime? postDate { get; set; }
        [StringLength(24)] //chất liệu
        public string? Material { get; set; }
        [DisplayFormat(DataFormatString = "{0:$0.##}")]
        public decimal? Price { get; set; }
        public string? Description { get; set; }

        [Range(0.01, 1, ErrorMessage = "Must be between 0.1 and 1")]
        public double? DiscountPercent { get; set; }

        [ForeignKey("Id")]
        public string? CategoryChildID { get; set; }
        public CategoryChild? CategoryChild { get; set; }

        public List<ProductColor>? Color { get; set; } = new List<ProductColor>();
        public List<ProductImage>? Image { get; set; } = new List<ProductImage>();


    }
}
