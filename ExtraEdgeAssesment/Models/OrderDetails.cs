using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtraaEdgeAssesment.Models
{
    [Table("orderdetails")]
    public class OrderDetails
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int MobileID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
