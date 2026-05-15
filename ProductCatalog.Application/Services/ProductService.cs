using MediatR;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Application.Products.Commands;
using ProductCatalog.Application.Products.Queries;

namespace ProductCatalog.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ProductDto> Create(CreateProductDto dto)
        {
            var productCreateCommand = new ProductCreateCommand() { Kod = dto.Kod, Nazwa = dto.Nazwa, Cena = dto.Cena };
            var result = await _mediator.Send(productCreateCommand);
            return new ProductDto() { Id = result.Id, Kod = result.Kod, Nazwa = result.Nazwa, Cena = result.Cena };
        }

        public async Task Delete(int id)
        {
            var productDeleteCommand = new ProductDeleteCommand(id);

            if (productDeleteCommand == null)
            {
                throw new Exception($"Product {id} couldn't be found!");
            }

            await _mediator.Send(productDeleteCommand);
        }

        public async Task<ProductDto> GetById(int id)
        {
            var getProductByIdQuery = new GetProductByIdQuery(id);

            if (getProductByIdQuery == null)
            {
                throw new Exception($"Product {id} couldn't be loaded!");
            }

            var result = await _mediator.Send(getProductByIdQuery);
            return new ProductDto() { Id = result.Id, Kod = result.Kod, Nazwa = result.Nazwa, Cena = result.Cena };
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var getProductsQuery = new GetProductsQuery();

            if (getProductsQuery == null)
            {
                throw new Exception("Products couldn't be loaded!");
            }

            var result = await _mediator.Send(getProductsQuery);

            return result.Select(r => new ProductDto() { Id = r.Id, Kod = r.Kod, Nazwa = r.Nazwa, Cena = r.Cena });
        }

        public async Task Update(int id, CreateProductDto dto)
        {
            var productUpdateCommand = new ProductUpdateCommand() { Id = id, Kod = dto.Kod, Nazwa = dto.Nazwa, Cena = dto.Cena };

            if (productUpdateCommand == null)
            {
                throw new Exception($"Product {id} couldn't be updated!");
            }

            await _mediator.Send(productUpdateCommand);
        }
    }
}
