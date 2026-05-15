using MediatR;
using ProductCatalog.Application.Products.Queries;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductReadRepository _repository;

        public GetProductsQueryHandler(IProductReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
