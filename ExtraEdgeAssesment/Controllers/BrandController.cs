using ExtraaEdgeAssesment.DTO;
using ExtraaEdgeAssesment.Models;
using ExtraaEdgeAssesment.Services;
using ExtraaEdgeAssesment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExtraaEdgeAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET: api/<BrandController>
        [HttpGet]
        [Route("GetBrands")]
        public IActionResult GetBrands()
        {
            try
            {
                var result = _brandService.GetBrands();
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
        [Route("GetBrandsById/{id}")]
        public IActionResult GetBrandsById(int id)
        {
            try
            {
                var result = _brandService.GetBrandById(id);
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
        [Route("AddBrand")]
        public IActionResult AddBrand([FromBody] Brand brand)
        {
            try
            {
                var result = _brandService.AddBrand(brand);
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
        [Route("UpdateBrand/{id}")]
        public IActionResult UpdateBrand([FromBody] Brand brand)
        {
            try
            {
                var result = _brandService.UpdateBrand(brand);
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
        [Route("DeleteBrand/{id}")]
        public IActionResult DeleteBrand(int id)
        {
            try
            {
                var result = _brandService.DeleteBrand(id);
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
        [Route("BulkInsertBrand")]
        public IActionResult BulkInsertBrand([FromBody] List<Brand> brands)
        {
            try
            {
                _brandService.BulkInsertBrand(brands);
                return StatusCode(StatusCodes.Status201Created);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        [HttpPut]
        [Route("BulkUpdateBrand")]
        public IActionResult BulkUpdateBrand([FromBody] List<Brand> brands)
        {
            try
            {
                _brandService.BulkInsertBrand(brands);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }
    }
}
