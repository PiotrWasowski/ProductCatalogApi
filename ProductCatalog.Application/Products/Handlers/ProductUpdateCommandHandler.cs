using MediatR;
using ProductCatalog.Application.Products.Commands;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler: IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductReadRepository _repositoryRead;
        private readonly IProductWriteRepository _repositoryWrite;

        public ProductUpdateCommandHandler(IProductReadRepository repositoryRead, IProductWriteRepository repositoryWrite)
        {
            _repositoryRead = repositoryRead;
            _repositoryWrite = repositoryWrite;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _repositoryRead.GetById(request.Id);
            
            if (productToUpdate == null)
            {
                throw new KeyNotFoundException($"Product with Id {request.Id} not found.");
            }

            productToUpdate.Update(request.Kod, request.Nazwa, request.Cena);

            return await _repositoryWrite.Update(productToUpdate);
        }
    }
}
