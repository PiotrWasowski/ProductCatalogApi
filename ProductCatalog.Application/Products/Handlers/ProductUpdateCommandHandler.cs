using MediatR;
using ProductCatalog.Application.Products.Commands;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler: IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductUpdateCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _repository.GetById(request.Id);
            
            if (productToUpdate == null)
            {
                throw new KeyNotFoundException($"Product with Id {request.Id} not found.");
            }

            productToUpdate.Update(request.Kod, request.Nazwa, request.Cena);

            return await _repository.Update(productToUpdate);
        }
    }
}
