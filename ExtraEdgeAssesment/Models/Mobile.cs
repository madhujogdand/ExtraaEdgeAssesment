using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtraaEdgeAssesment.Models
{
    [Table("mobile")]
    public class Mobile
    {
        [Key]
        public int MobileID { get; set; }
        public int BrandID { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
    }
}
