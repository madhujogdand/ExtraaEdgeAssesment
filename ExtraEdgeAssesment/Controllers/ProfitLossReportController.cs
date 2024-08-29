using ExtraaEdgeAssesment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExtraaEdgeAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfitLossReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ProfitLossReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        // GET: api/<ProfitLossReportController>
        [HttpGet]
        [Route("GetProfitLoss")]
        public IActionResult GetProfitLoss([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var brandSales = _reportService.GetProfitLoss(startDate, endDate);
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
