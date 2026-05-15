
using MediatR;
using ProductCatalog.Application.Products.Commands;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Application.Products.Handlers
{
    public class ProductDeleteCommandHandler: IRequestHandler<ProductDeleteCommand, Product>
    {
        private readonly IProductWriteRepository _repositoryWrite;
        private readonly IProductReadRepository _repositoryRead;
        public ProductDeleteCommandHandler(IProductWriteRepository repositoryWrite, IProductReadRepository repositoryRead)
        {
            _repositoryWrite = repositoryWrite;
            _repositoryRead = repositoryRead;
        }

        public async Task<Product> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var product = await _repositoryRead.GetById(request.Id);
            
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {request.Id} not found.");
            }

            return await _repositoryWrite.Delete(request.Id);
        }
    }
}
