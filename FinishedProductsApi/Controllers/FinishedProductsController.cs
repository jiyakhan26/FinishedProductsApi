using FinishedProductsApi.Models;
using FinishedProductsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinishedProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinishedProductsController : ControllerBase
    {
        private readonly IFinishedProductService _finishedProductService;

        public FinishedProductsController(IFinishedProductService finishedProductService)
        {
            _finishedProductService = finishedProductService;
        }

        // GET: api/finishedproducts?page=1&pageSize=10
        [HttpGet]
        public async Task<ActionResult<PagedResult<FinishedProduct>>> GetAllProducts([FromQuery] PaginationParams paginationParams)
        {
            try
            {
                var products = await _finishedProductService.GetAllAsync(paginationParams);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/finishedproducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishedProduct>> GetProduct(int id)
        {
            try
            {
                var product = await _finishedProductService.GetByIdAsync(id);

                if (product == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/finishedproducts/category?name=Electronics&page=1&pageSize=10
        [HttpGet("category")]
        public async Task<ActionResult<PagedResult<FinishedProduct>>> GetProductsByCategory([FromQuery] string name, [FromQuery] PaginationParams paginationParams)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("Category name cannot be empty.");
                }

                var products = await _finishedProductService.GetByCategoryAsync(name, paginationParams);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/finishedproducts/manufacturer?name=ManufacturerName&page=1&pageSize=10
        [HttpGet("manufacturer")]
        public async Task<ActionResult<PagedResult<FinishedProduct>>> GetProductsByManufacturer([FromQuery] string name, [FromQuery] PaginationParams paginationParams)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("Manufacturer name cannot be empty.");
                }

                var products = await _finishedProductService.GetByManufacturerAsync(name, paginationParams);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/finishedproducts/producttype?name=TypeName&page=1&pageSize=10
        [HttpGet("producttype")]
        public async Task<ActionResult<PagedResult<FinishedProduct>>> GetProductsByType([FromQuery] string name, [FromQuery] PaginationParams paginationParams)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("Product type name cannot be empty.");
                }

                var products = await _finishedProductService.GetByProductTypeAsync(name, paginationParams);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/finishedproducts/department?name=DepartmentName&page=1&pageSize=10
        [HttpGet("department")]
        public async Task<ActionResult<PagedResult<FinishedProduct>>> GetProductsByDepartment([FromQuery] string name, [FromQuery] PaginationParams paginationParams)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("Department name cannot be empty.");
                }

                var products = await _finishedProductService.GetByDepartmentAsync(name, paginationParams);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/finishedproducts/gender?name=Male&page=1&pageSize=10
        [HttpGet("gender")]
        public async Task<ActionResult<PagedResult<FinishedProduct>>> GetProductsByGender([FromQuery] string name, [FromQuery] PaginationParams paginationParams)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("Gender cannot be empty.");
                }

                var products = await _finishedProductService.GetByGenderAsync(name, paginationParams);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/finishedproducts/year/2024?page=1&pageSize=10
        [HttpGet("year/{year}")]
        public async Task<ActionResult<PagedResult<FinishedProduct>>> GetProductsByYear(int year, [FromQuery] PaginationParams paginationParams)
        {
            try
            {
                var products = await _finishedProductService.GetByProductYearAsync(year, paginationParams);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/finishedproducts/active?page=1&pageSize=10
        [HttpGet("active")]
        public async Task<ActionResult<PagedResult<FinishedProduct>>> GetActiveProducts([FromQuery] PaginationParams paginationParams)
        {
            try
            {
                var products = await _finishedProductService.GetActiveProductsAsync(paginationParams);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/finishedproducts/search?name=productname&page=1&pageSize=10
        [HttpGet("search")]
        public async Task<ActionResult<PagedResult<FinishedProduct>>> SearchProducts([FromQuery] string name, [FromQuery] PaginationParams paginationParams)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("Product name cannot be empty.");
                }

                var products = await _finishedProductService.SearchByNameAsync(name, paginationParams);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/finishedproducts/filter-by-ids
        [HttpPost("filter-by-ids")]
        public async Task<ActionResult<PagedResult<FinishedProduct>>> GetProductsByIds([FromBody] FilterByIdsRequest request, [FromQuery] PaginationParams paginationParams)
        {
            try
            {
                if (request?.Ids == null || !request.Ids.Any())
                {
                    return BadRequest("At least one ID must be provided.");
                }

                var products = await _finishedProductService.GetByMultipleIdsAsync(request.Ids, paginationParams);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/finishedproducts/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetTotalCount()
        {
            try
            {
                var count = await _finishedProductService.GetTotalCountAsync();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    // Request model for filtering by multiple IDs
    public class FilterByIdsRequest
    {
        public List<int> Ids { get; set; } = new List<int>();
    }
}