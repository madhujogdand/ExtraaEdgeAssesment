using ExtraaEdgeAssesment.DTO;

namespace ExtraaEdgeAssesment.Services.Interfaces
{
    public interface IReportService
    {
        public IEnumerable<MonthlySalesDto> GetMonthlySales(DateTime startDate, DateTime endDate);
        public IEnumerable<MonthlyBrandSalesDto> GetMonthlyBrandSales(DateTime startDate, DateTime endDate);
        public ProfitLossDto GetProfitLoss(DateTime startDate, DateTime endDate);
    }
}
