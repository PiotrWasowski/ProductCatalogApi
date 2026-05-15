using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Interfaces
{
    public interface IProductReadRepository
    {
        Task<Product> GetById(int id);
        Task<IEnumerable<Product>> GetAll();
    }
}
