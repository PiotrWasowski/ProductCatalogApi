using ProductCatalogApi.Models;
using ProductCatalogApi.Repositories;

namespace ProductCatalogApi.Application.Products.Queries
{
    public class GetProductsQueryHandler
    {
        private readonly IProductRepository _repository;

        public GetProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<Product> Handle()
        {
            return _repository.GetAll();
        }
    }
}