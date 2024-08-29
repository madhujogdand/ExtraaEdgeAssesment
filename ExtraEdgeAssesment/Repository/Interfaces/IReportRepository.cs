using ExtraaEdgeAssesment.DTO;

namespace ExtraaEdgeAssesment.Repository.Interfaces
{
    public interface IReportRepository
    {
        public IEnumerable<MonthlySalesDto> GetMonthlySales(DateTime startDate, DateTime endDate);
        public IEnumerable<MonthlyBrandSalesDto> GetMonthlyBrandSales(DateTime startDate, DateTime endDate);
        public ProfitLossDto GetProfitLoss(DateTime startDate, DateTime endDate);
    }
}
