using ExtraaEdgeAssesment.Models;
using ExtraaEdgeAssesment.Services;
using ExtraaEdgeAssesment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExtraaEdgeAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<BrandController>
        [HttpGet]
        [Route("GetOrders")]
        public IActionResult GetOrders()
        {
            try
            {
                var result = _orderService.GetOrders();
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
        [Route("GetOrderById/{id}")]
        public IActionResult GetOrderById(int id)
        {
            try
            {
                var result = _orderService.GetOrderById(id);
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
        [Route("AddOrder")]
        public IActionResult AddOrder([FromBody] Orders orders)
        {
            try
            {
                var result = _orderService.AddOrder(orders);
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
        [Route("UpdateOrder/{id}")]
        public IActionResult UpdateOrder([FromBody] Orders orders)
        {
            try
            {
                var result = _orderService.UpdateOrder(orders);
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
        [Route("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                var result = _orderService.DeleteOrder(id);
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
        [Route("BulkInsertOrders")]
        public IActionResult BulkInsertOrders([FromBody] List<Orders> orders)
        {
            try
            {
                _orderService.BulkInsertOrders(orders);
                return StatusCode(StatusCodes.Status201Created);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        [HttpPut]
        [Route("BulkUpdateOrders")]
        public IActionResult BulkUpdateOrders([FromBody] List<Orders> orders)
        {
            try
            {
                _orderService.BulkUpdateOrders(orders);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }
    }
}
