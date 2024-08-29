using ExtraaEdgeAssesment.Data;
using ExtraaEdgeAssesment.DTO;
using ExtraaEdgeAssesment.Repository.Interfaces;

namespace ExtraaEdgeAssesment.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<MonthlyBrandSalesDto> GetMonthlyBrandSales(DateTime startDate, DateTime endDate)
        {
            var monthlyBrandSales = from o in _context.OrderDetails
                                    join od in _context.Orders on o.OrderID equals od.OrderID
                                    join m in _context.Mobiles on o.MobileID equals m.MobileID
                                    join b in _context.Brands on m.BrandID equals b.BrandID
                                    where od.OrderDate >= startDate && od.OrderDate <= endDate
                                    group new { b.BrandName, o.TotalPrice, o.Quantity, o.Discount } by b.BrandName into g
                                    select new MonthlyBrandSalesDto
                                    {
                                        BrandName = g.Key,
                                        TotalSales = g.Sum(x => x.TotalPrice),
                                        TotalQuantitySold=g.Sum(x => x.Quantity),
                                        TotalDiscounts = g.Sum(x => x.Discount),
                                        TotalAmountAfterDiscount = g.Sum(x => x.TotalPrice - x.Discount)
                                    };

            return monthlyBrandSales.ToList();
        }

        public IEnumerable<MonthlySalesDto> GetMonthlySales(DateTime startDate, DateTime endDate)
        {
            var monthlySales = from o in _context.OrderDetails
                               join od in _context.Orders on o.OrderID equals od.OrderID
                               where od.OrderDate >= startDate && od.OrderDate <= endDate
                               group new { od.OrderDate, o.TotalPrice,o.Quantity,o.Discount } by new { od.OrderDate.Year, od.OrderDate.Month } into g
                               select new MonthlySalesDto
                               {
                                   StartDate=startDate,
                                   EndDate=endDate, 
                                   TotalSales = g.Sum(x => x.TotalPrice),
                                   TotalQuantitySold = g.Sum(x => x.Quantity),
                                   TotalDiscounts = g.Sum(x => x.Discount),
                                   TotalAmountAfterDiscount = g.Sum(x => x.TotalPrice - x.Discount)
                               };

            return monthlySales.ToList();
        }

        public ProfitLossDto GetProfitLoss(DateTime startDate, DateTime endDate)
        {
            // Define the previous period's date range
            var previousStartDate = startDate.AddMonths(-1);
            var previousEndDate = endDate.AddMonths(-1);

            // Current period sales
            var currentPeriodSales = (from o in _context.OrderDetails
                                      join od in _context.Orders on o.OrderID equals od.OrderID
                                      where od.OrderDate >= startDate && od.OrderDate <= endDate
                                      group new { o.TotalPrice, o.Discount } by 1 into g
                                      select new
                                      {
                                          TotalSales = g.Sum(x => x.TotalPrice),
                                          TotalDiscounts = g.Sum(x => x.Discount)
                                      }).FirstOrDefault();

            // Previous period sales
            var previousPeriodSales = (from o in _context.OrderDetails
                                       join od in _context.Orders on o.OrderID equals od.OrderID
                                       where od.OrderDate >= previousStartDate && od.OrderDate <= previousEndDate
                                       group new { o.TotalPrice, o.Discount } by 1 into g
                                       select new
                                       {
                                           TotalSales = g.Sum(x => x.TotalPrice),
                                           TotalDiscounts = g.Sum(x => x.Discount)
                                       }).FirstOrDefault();

            // Calculate profit or loss based on total sales and discounts
            var currentSales = currentPeriodSales?.TotalSales ?? 0;
            var previousSales = previousPeriodSales?.TotalSales ?? 0;
            var currentDiscounts = currentPeriodSales?.TotalDiscounts ?? 0;
            var previousDiscounts = previousPeriodSales?.TotalDiscounts ?? 0;

            // Determine the profit/loss based on total sales difference
            var profitLoss = (currentSales - currentDiscounts) - (previousSales - previousDiscounts);

            return new ProfitLossDto
            {
                TotalSale = currentSales + previousSales,
                CurrentPeriodSales = currentSales,
                PreviousPeriodSales = previousSales,
                TotalDiscount = currentDiscounts,
                ProfitLoss = profitLoss
             
            };
        }

    }
}
