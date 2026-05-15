using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Interfaces
{
    public interface IProductWriteRepository
    {
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(int id);
    }
}
