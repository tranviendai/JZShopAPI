using System.ComponentModel.DataAnnotations.Schema;

namespace JZeno.Models
{
    public class CategoryChild
    {
        public string? Id { get; set; }
        public string? Name { get; set; }

        [ForeignKey("Id")]
        public string? CategoryID { get; set; }
        public Category? Category { get; set; }

        public ICollection<Product>? Product { get; set; }

    }
}
