using ProductCatalogApi.Models;

namespace ProductCatalogApi.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>() { new Product { Id = 1, Kod = "P001", Nazwa = "Sample Product", Cena = 9.99M } };
        private int _nextId = 2;

        public void Add(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
        }

        public List<Product> GetAll()
        {
            return _products;
        }
    }
}
