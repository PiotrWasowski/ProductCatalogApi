
using MediatR;
using ProductCatalog.Application.Products.Commands;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Application.Products.Handlers
{
    public class ProductDeleteCommandHandler: IRequestHandler<ProductDeleteCommand, Product>
    {
        private readonly IProductRepository _repository;
        public ProductDeleteCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.Id);
            
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {request.Id} not found.");
            }

            return await _repository.Delete(request.Id);
        }
    }
}
