using MediatR;
using ProductCatalog.Application.Products.Queries;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductReadRepository _repository;

        public GetProductByIdQueryHandler(IProductReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.Id);
        }
    }
}
