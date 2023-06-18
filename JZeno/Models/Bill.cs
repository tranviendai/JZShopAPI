using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JZeno.Models
{
    public class Bill
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string? Address { get; set; }
        public decimal? Total { get; set; }
        public DateTime? DateCreated { get; set; }
        [StringLength(14)]
        public string? Status { get; set; }
        [ForeignKey("Id")]
        public string? ShipID { get; set; }
        public Ship? Ship { get; set; }

        [ForeignKey("Id")]
        public string? UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Id")]
        public string? VoucherID { get; set; }
        public Voucher? Voucher { get; set; }
    }
}
