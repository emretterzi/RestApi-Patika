using Microsoft.AspNetCore.Mvc;
using RestApi.Dto;

using RestApi.Service;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound(); // 404 Not Found
            }

            return Ok(product); // 200 OK
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            _productService.CreateProduct(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product); // 201 Created
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            try
            {
                _productService.UpdateProduct(id, updatedProduct);
                return Ok(updatedProduct); // 200 OK
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // 404 Not Found
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return NoContent(); // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // 404 Not Found
            }
        }

        [HttpGet("list")]
        public IActionResult ListProducts([FromQuery] string name)
        {
            var filteredProducts = _productService.ListProducts(name);
            return Ok(filteredProducts);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchProduct(int id, [FromBody] Product product)
        {
            try
            {
                _productService.PatchProduct(id, product);
                return NoContent(); // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // 404 Not Found
            }
        }
    }
}
