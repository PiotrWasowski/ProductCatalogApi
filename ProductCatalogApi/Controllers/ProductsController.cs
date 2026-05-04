using Microsoft.AspNetCore.Mvc;
using ProductCatalogApi.Application.Products.Commands;
using ProductCatalogApi.Application.Products.Handlers;
using ProductCatalogApi.Application.Products.Queries;
using ProductCatalogApi.Dtos;
using ProductCatalogApi.Models;

namespace ProductCatalogApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController: ControllerBase
    {
        private readonly GetProductsQueryHandler _getHandler;
        private readonly CreateProductCommandHandler _createHandler;
        private readonly DeleteProductCommandHandler _deleteHandler;

        public ProductsController(GetProductsQueryHandler getHandler, CreateProductCommandHandler createHandler, DeleteProductCommandHandler deleteHandler)
        {
            _getHandler = getHandler;
            _createHandler = createHandler;
            _deleteHandler = deleteHandler;
        }

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var products = _getHandler.Handle();

            var result = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Kod = p.Kod,
                Nazwa = p.Nazwa,
                Cena = p.Cena
            });

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Add(CreateProductDto dto)
        {
            var command = new CreateProductCommand
            {
                Kod = dto.Kod,
                Nazwa = dto.Nazwa,
                Cena = dto.Cena
            };

            _createHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var command = new DeleteProductCommand
            {
                Id = id
            };

            _deleteHandler.Handle(command);
            return Ok();
        }
    }
}
