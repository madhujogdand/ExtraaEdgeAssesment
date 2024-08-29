using ExtraaEdgeAssesment.Data;
using ExtraaEdgeAssesment.Repository.Interfaces;

namespace ExtraaEdgeAssesment.Repository
{
    public class MobileBestPriceRepository : IMobileBestPriceRepository
    {
        private readonly ApplicationDbContext _context;
        public MobileBestPriceRepository(ApplicationDbContext db)
        {
            this._context = db;
        }
        public decimal GetBestPrice(int mobileId, DateTime fromDate, DateTime toDate)
        {
            var bestPrice = (from mh in _context.MobilePriceHistories
                             join m in _context.Mobiles on mh.MobileID equals m.MobileID
                             where mh.MobileID == mobileId && mh.EffectiveDate >= fromDate && mh.EffectiveDate <= toDate
                             group mh by mh.Price into priceGroup
                             orderby priceGroup.Count() descending
                             select (decimal?)priceGroup.Key)
                  .FirstOrDefault();


            return bestPrice ?? 0;
        }
    }
}
