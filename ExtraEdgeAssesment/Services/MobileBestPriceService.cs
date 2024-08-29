using ExtraaEdgeAssesment.Repository.Interfaces;
using ExtraaEdgeAssesment.Services.Interfaces;

namespace ExtraaEdgeAssesment.Services
{
    public class MobileBestPriceService : IMobileBestPriceService
    {
        private readonly IMobileBestPriceRepository repo;
        public MobileBestPriceService(IMobileBestPriceRepository repo)
        {
            this.repo = repo;
        }
        public decimal GetBestPrice(int mobileId, DateTime fromDate, DateTime toDate)
        {
            return repo.GetBestPrice(mobileId, fromDate, toDate);
        }
    }
}
