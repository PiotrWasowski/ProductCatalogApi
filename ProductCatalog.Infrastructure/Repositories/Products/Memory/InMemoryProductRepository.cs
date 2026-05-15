using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Infrastructure.Repositories.Products.Memory
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly Dictionary<int, Product> _products = new();
        private int _nextId = 1;
        private readonly object _lock = new();

        public Task<Product> Create(Product product)
        {
            lock (_lock)
            {
                var newProduct = new Product(_nextId++, product.Kod, product.Nazwa, product.Cena);
                _products.Add(newProduct.Id, newProduct);
                return Task.FromResult(newProduct);
            }
        }

        public Task<Product> Delete(int id)
        {
            lock (_lock)
            {
                if (!_products.TryGetValue(id, out var product))
                {
                    throw new KeyNotFoundException($"Product with Id {id} not found.");
                }

                _products.Remove(id);

                return Task.FromResult(product);
            }
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            return Task.FromResult(_products.Values.AsEnumerable());
        }

        public Task<Product> GetById(int id)
        {
            if (!_products.TryGetValue(id, out var product))
            {
                throw new KeyNotFoundException($"Product with Id {id} not found.");
            }

            return Task.FromResult(product);
        }

        public Task<Product> Update(Product product)
        {
            lock (_lock)
            {
                ArgumentNullException.ThrowIfNull(product);

                if (!_products.TryGetValue(product.Id, out var existing))
                {
                    throw new KeyNotFoundException($"Product with Id {product.Id} not found.");
                }
                
                existing.Update(product.Kod, product.Nazwa, product.Cena);

                return Task.FromResult(existing);
            }
        }
    }
}
