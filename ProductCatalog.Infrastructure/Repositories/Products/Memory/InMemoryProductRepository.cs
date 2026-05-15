using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;
using System.Collections.Concurrent;

namespace ProductCatalog.Infrastructure.Repositories.Products.Memory
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly ConcurrentDictionary<int, Product> _products = new();
        private int _nextId = 1;

        public Task<IEnumerable<Product>> GetAll()
        {
            var snapshot = _products.Values.ToList();
            return Task.FromResult(snapshot.AsEnumerable());
        }

        public Task<Product> GetById(int id)
        {
            if (!_products.TryGetValue(id, out var product))
            {
                throw new KeyNotFoundException($"Product with Id {id} not found.");
            }

            return Task.FromResult(product);
        }

        public Task<Product> Create(Product product)
        {
            var newId = Interlocked.Increment(ref _nextId);
            var newProduct = new Product(newId, product.Kod, product.Nazwa, product.Cena);
            
            var added = _products.TryAdd(newProduct.Id, newProduct);
            
            if (!added)
            {
                throw new InvalidOperationException($"Failed to add product with Id {newProduct.Id}.");
            }

            return Task.FromResult(newProduct);
        }

        public Task<Product> Delete(int id)
        {
            if (!_products.TryRemove(id, out var deletedProduct))
            {
                throw new KeyNotFoundException($"Product with Id {id} not found.");
            }

            return Task.FromResult(deletedProduct);   
        }

        public Task<Product> Update(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            if (!_products.ContainsKey(product.Id))
            {
                throw new KeyNotFoundException($"Product with Id {product.Id} not found.");
            }

            var updatedProduct = new Product(product.Id, product.Kod, product.Nazwa, product.Cena);
            _products[product.Id] = updatedProduct;

            return Task.FromResult(updatedProduct);
        }
    }
}
