using System.ComponentModel.DataAnnotations;

namespace JZeno.Models
{
    public class Voucher
    {
        [Key]
        [StringLength(10)]
        public string? Id { get; set; }
        [StringLength(20)]
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? limit { get; set; }
        [StringLength(100)]
        public string? Description { get; set; }
    }
}
