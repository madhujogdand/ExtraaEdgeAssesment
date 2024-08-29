using ExtraaEdgeAssesment.Services;
using ExtraaEdgeAssesment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExtraaEdgeAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileBestPriceController : ControllerBase
    {
        private IMobileBestPriceService _mobileBestPriceService;

        public MobileBestPriceController(IMobileBestPriceService mobileBestPriceService)
        {
            _mobileBestPriceService = mobileBestPriceService;
        }

        [HttpGet]
        [Route("GetBestPrice/{mobileId}")]
        public IActionResult GetBestPrice(int mobileId, [FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            try
            { 
                var bestPrice = _mobileBestPriceService.GetBestPrice(mobileId, fromDate, toDate);

                if (bestPrice > 0)
                {
                    return Ok(new { MobileID = mobileId, BestPrice = bestPrice });
                }
                else
                {
                    return NotFound(new { Message = "No price history found for the specified mobile and date range." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }
    }
}
