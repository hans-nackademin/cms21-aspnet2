using _00_WebApi.Models.Product;
using _00_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _00_WebApi.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var result = await _service.CreateAsync(product);
            if (result != null)
                return new OkObjectResult(result);

            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _service.GetAll());
        }

        [HttpGet("{artnr}")]
        public async Task<IActionResult> Get(string artnr)
        {
            var result = await _service.Get(artnr);
            if (result != null)
                return new OkObjectResult(result);

            return new NotFoundResult();
        }
    }
}
