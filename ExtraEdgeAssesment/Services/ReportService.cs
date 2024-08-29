using ExtraaEdgeAssesment.DTO;
using ExtraaEdgeAssesment.Repository.Interfaces;
using ExtraaEdgeAssesment.Services.Interfaces;

namespace ExtraaEdgeAssesment.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public IEnumerable<MonthlyBrandSalesDto> GetMonthlyBrandSales(DateTime startDate, DateTime endDate)
        {
            return _reportRepository.GetMonthlyBrandSales(startDate, endDate);
        }

        public IEnumerable<MonthlySalesDto> GetMonthlySales(DateTime startDate, DateTime endDate)
        {
            return _reportRepository.GetMonthlySales(startDate, endDate);
        }

        public ProfitLossDto GetProfitLoss(DateTime startDate, DateTime endDate)
        {
            return _reportRepository.GetProfitLoss(startDate, endDate);
        }
    }
}
