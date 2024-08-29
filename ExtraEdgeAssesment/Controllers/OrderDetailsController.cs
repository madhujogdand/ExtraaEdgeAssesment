using ExtraaEdgeAssesment.Models;
using ExtraaEdgeAssesment.Services;
using ExtraaEdgeAssesment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExtraaEdgeAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        // GET: api/<BrandController>
        [HttpGet]
        [Route("GetOrderDetails")]
        public IActionResult GetOrderDetails()
        {
            try
            {
                var result = _orderDetailsService.GetOrderDetails();
                if (result != null)
                {
                    return new ObjectResult(result);
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

        // GET api/<BrandController>/5
        [HttpGet]
        [Route("GetOrderDetailsById/{id}")]
        public IActionResult GetOrderDetailsById(int id)
        {
            try
            {
                var result = _orderDetailsService.GetOrderDetailsById(id);
                if (result != null)
                {
                    return new ObjectResult(result);
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

        // POST api/<BrandController>
        [HttpPost]
        [Route("AddOrderDetails")]
        public IActionResult AddOrderDetails([FromBody] OrderDetails orderDetails)
        {
            try
            {
                var result = _orderDetailsService.AddOrderDetails(orderDetails);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        [Route("UpdateOrderDetails/{id}")]
        public IActionResult UpdateOrderDetails([FromBody] OrderDetails orderDetails)
        {
            try
            {
                var result = _orderDetailsService.UpdateOrderDetails(orderDetails);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        // DELETE api/<BrandController>/5
        [HttpDelete]
        [Route("DeleteOrderDetails/{id}")]
        public IActionResult DeleteOrderDetails(int id)
        {
            try
            {
                var result = _orderDetailsService.DeleteOrderDetails(id);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        [HttpPost]
        [Route("BulkInsertOrderDetails")]
        public IActionResult BulkInsertOrderDetails([FromBody] List<OrderDetails> orderdetails)
        {
            try
            {
                _orderDetailsService.BulkInsertOrderDetails(orderdetails);
                return StatusCode(StatusCodes.Status201Created);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        [HttpPut]
        [Route("BulkUpdateOrderDetails")]
        public IActionResult BulkUpdateOrderDetails([FromBody] List<OrderDetails> orderdetails)
        {
            try
            {
                _orderDetailsService.BulkUpdateOrderDetails(orderdetails);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }
    }
}
