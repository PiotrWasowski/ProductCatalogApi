using Microsoft.AspNetCore.Mvc;
using ProductCatalogApi.Application.Products.Commands;
using ProductCatalogApi.Application.Products.Queries;
using ProductCatalogApi.Models;

namespace ProductCatalogApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController: ControllerBase
    {
        private readonly GetProductsQueryHandler _getHandler;
        private readonly CreateProductCommandHandler _createHandler;

        public ProductsController(GetProductsQueryHandler getHandler, CreateProductCommandHandler createHandler)
        {
            _getHandler = getHandler;
            _createHandler = createHandler;
        }

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return Ok(_getHandler.Handle());
        }

        [HttpPost]
        public ActionResult Add(CreateProductCommand command)
        {
            _createHandler.Handle(command);
            return Ok();
        }
    }
}
