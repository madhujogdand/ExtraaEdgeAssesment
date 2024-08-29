using ExtraaEdgeAssesment.DTO;
using ExtraaEdgeAssesment.Models;
using ExtraaEdgeAssesment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExtraaEdgeAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private IMobileService _mobileService;

        public MobileController(IMobileService mobileService)
        {
            _mobileService = mobileService;
        }

        // GET: api/<BrandController>
        [HttpGet]
        [Route("GetMobiles")]
        public IActionResult GetMobiles()
        {
            try
            {
                var result = _mobileService.GetMobiles();
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
        [Route("GetMobileById/{id}")]
        public IActionResult GetMobileById(int id)
        {
            try
            {
                var result = _mobileService.GetMobileById(id);
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
        [Route("AddMobile")]
        public IActionResult AddMobile([FromBody] Mobile mobile)
        {
            try
            {
                var result = _mobileService.AddMobile(mobile);
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
        [Route("UpdateMobile/{id}")]
        public IActionResult UpdateMobile([FromBody] Mobile mobile)
        {
            try
            {
                var result = _mobileService.UpdateMobile(mobile);
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
        [Route("DeleteMobile/{id}")]
        public IActionResult DeleteMobile(int id)
        {
            try
            {
                var result = _mobileService.DeleteMobile(id);
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
        [Route("BulkInsertMobile")]
        public IActionResult BulkInsertMobile([FromBody] List<Mobile> mobiles)
        {
            try
            {
                 _mobileService.BulkInsertMobile(mobiles);
                  return StatusCode(StatusCodes.Status201Created);
               
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        [HttpPut]
        [Route("BulkUpdateMobile")]
        public IActionResult BulkUpdateMobile([FromBody] List<Mobile> mobiles)
        {
            try
            {
                _mobileService.BulkUpdateMobile(mobiles);
               
                    return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }
       
    }
}
