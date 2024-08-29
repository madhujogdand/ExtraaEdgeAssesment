using ExtraaEdgeAssesment.Services;
using ExtraaEdgeAssesment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExtraaEdgeAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public SalesReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        // GET: api/<SalesReportController>
        [HttpGet]
        [Route("GetMonthlySales")]
        public IActionResult GetMonthlySales([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var sales = _reportService.GetMonthlySales(startDate,endDate);
                if (sales != null)
                {
                    return new ObjectResult(sales);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // GET api/<SalesReportController>/5
        [HttpGet]
        [Route("GetMonthlyBrandSales")]
        public IActionResult GetMonthlyBrandSales([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var brandSales = _reportService.GetMonthlyBrandSales(startDate, endDate);
                if (brandSales != null)
                {
                    return new ObjectResult(brandSales);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        
    }
}
