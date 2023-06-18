using System.ComponentModel.DataAnnotations.Schema;

namespace JZeno.Models
{
    public class DetailOrder
    {
        public int Id { get; set; }
        [ForeignKey("Id")]
        public int? BillID { get; set; }
        public Bill? Bill { get; set; }
        [ForeignKey("Id")]
        public string? ProductID { get; set; }
        public Product? Product { get; set; }
    }
}
