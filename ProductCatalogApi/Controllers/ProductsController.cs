using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;

namespace ProductCatalogApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController: ControllerBase
    {
       private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var products = await _productService.GetProducts();

            if (products == null || !products.Any())
            {
                return NotFound("Products nof found");
            }

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound($"Product with id {id} not found");
            }
            return Ok(product);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] CreateProductDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid product data");
            }
            var existingProduct = await _productService.GetById(id);
            if (existingProduct == null)
            {
                return NotFound($"Product with id {id} not found");
            }
            await _productService.Update(id, dto);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Add([FromBody] CreateProductDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid product data");
            }

            var createdProduct = await _productService.Create(dto);

            return Ok(createdProduct);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound($"Product with id {id} not found");
            }

            await _productService.Delete(id);
            return Ok();
        }
    }
}
