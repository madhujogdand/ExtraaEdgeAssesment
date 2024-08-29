namespace ExtraaEdgeAssesment.DTO
{
    public class ProfitLossDto
    {
        public decimal TotalSale { get; set; }
        public decimal CurrentPeriodSales { get; set; }
        public decimal PreviousPeriodSales { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal ProfitLoss { get; set; }
        
    }
}
