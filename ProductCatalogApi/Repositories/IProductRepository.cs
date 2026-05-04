using ProductCatalogApi.Models;

namespace ProductCatalogApi.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        void Add(Product product); 
    }
}
