namespace ExtraaEdgeAssesment.Services.Interfaces
{
    public interface IMobileBestPriceService
    {
        public decimal GetBestPrice(int mobileId, DateTime fromDate, DateTime toDate);
    }
}
