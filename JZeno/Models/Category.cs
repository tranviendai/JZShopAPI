using System.ComponentModel.DataAnnotations;

namespace JZeno.Models
{
    public class Category
    {
        public string? Id { get; set; }
        [StringLength(24)]
        public string? Name { get; set; }
        public ICollection<CategoryChild>? CategoryChild { get; set;}
    }

}
