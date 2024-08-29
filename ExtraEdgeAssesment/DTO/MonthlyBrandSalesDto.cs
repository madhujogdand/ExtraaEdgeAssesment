namespace ExtraaEdgeAssesment.DTO
{
    public class MonthlyBrandSalesDto
    {
        public string BrandName { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalDiscounts { get; set; }
        public decimal TotalAmountAfterDiscount { get; set; }
    }
}
