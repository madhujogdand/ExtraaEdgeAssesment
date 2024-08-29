namespace ExtraaEdgeAssesment.DTO
{
    public class MonthlySalesDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalDiscounts { get; set; }
        public decimal TotalAmountAfterDiscount { get; set; }
       
    }
}
