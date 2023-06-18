using System.ComponentModel.DataAnnotations;

namespace JZeno.Models
{
    public class Ship
    {
        [Key]
        [StringLength(10)]
        public string? Id { get; set; }
        [StringLength(42)]
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        [StringLength(12)]
        public string? Status { get; set; }
        public ICollection<Bill>? Bill { get; set; }
    }
}
