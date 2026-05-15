using MediatR;
using ProductCatalog.Application.Products.Commands;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductCreateCommandHandler(IProductRepository repository) 
        { 
            _repository = repository; 
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Kod, request.Nazwa, request.Cena);

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            else
            {
                return await _repository.Create(product);
            }
        }
    }
}
