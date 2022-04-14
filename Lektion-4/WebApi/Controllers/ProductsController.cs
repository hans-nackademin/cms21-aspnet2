using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return new OkObjectResult(await _service.GetAllProductsAsync());
        }
    }
}
