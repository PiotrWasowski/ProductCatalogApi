using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;
using System.Collections.Concurrent;

namespace ProductCatalog.Infrastructure.Repositories.Products.Memory
{
    public sealed class InMemoryProductRepository : IProductReadRepository, IProductWriteRepository
    {
        private readonly ConcurrentDictionary<int, Product> _products = new();
        private int _nextId = 0;

        public Task<IEnumerable<Product>> GetAll()
        {
            var snapshot = _products.Values.ToList();
            return Task.FromResult<IEnumerable<Product>>(snapshot);
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
            ArgumentNullException.ThrowIfNull(product);
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

            if (!_products.TryGetValue(product.Id, out var existing))
            {
                throw new KeyNotFoundException($"Product with Id {product.Id} not found.");
            }

            var updatedProduct = new Product(product.Id, product.Kod, product.Nazwa, product.Cena);
            if (!_products.TryUpdate(product.Id, updatedProduct, existing))
            {
                throw new InvalidOperationException($"Failed to update product with Id {product.Id}.");
            }

            return Task.FromResult(updatedProduct);
        }
    }
}
