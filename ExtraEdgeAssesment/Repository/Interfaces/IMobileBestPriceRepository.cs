namespace ExtraaEdgeAssesment.Repository.Interfaces
{
    public interface IMobileBestPriceRepository
    {
        public decimal GetBestPrice(int mobileId, DateTime fromDate, DateTime toDate);
    }
}
