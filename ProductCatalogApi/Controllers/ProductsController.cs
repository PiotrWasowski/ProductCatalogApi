using Microsoft.AspNetCore.Mvc;
using ProductCatalogApi.Models;
using ProductCatalogApi.Repositories;

namespace ProductCatalogApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController: ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            _repository.Add(product);
            return Ok();
        }
    }
}
