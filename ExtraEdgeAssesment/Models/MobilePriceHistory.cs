using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtraaEdgeAssesment.Models
{
    [Table("mobilepricehistory")]
    public class MobilePriceHistory
    {
        [Key]
        public int PriceHistoryID { get; set; }
        public int MobileID { get; set; }
        public decimal Price { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
