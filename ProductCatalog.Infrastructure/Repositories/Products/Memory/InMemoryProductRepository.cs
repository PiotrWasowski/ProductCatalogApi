using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Infrastructure.Repositories.Products.Memory
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();
        private int _nextId = 2;

        public async Task<Product> Create(Product product)
        {
            var newProduct = new Product(_nextId++, product.Kod, product.Nazwa, product.Cena);
            _products.Add(newProduct);
            return await Task.FromResult(newProduct);
        }

        public async Task<Product> Delete(int id)
        {
            if (_products != null && _products.Any() && _products.Exists(p => p.Id == id))
            {
                var productToDelete = _products.FirstOrDefault(p => p.Id == id);
                if (_products.Remove(productToDelete))
                {
                    return await Task.FromResult(productToDelete);
                }
                else
                {
                    throw new Exception($"Failed to delete product with id {id}.");
                }
            }
            else
            {
                throw new KeyNotFoundException($"Product with Id {id} not found.");
            }
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            if (_products == null || !_products.Any())
            {
                throw new Exception("No products found.");
            }
            else
            {
                return Task.FromResult(_products.AsEnumerable());
            }
        }

        public Task<Product> GetById(int id)
        {
            if (!_products.Any())
            {
                throw new KeyNotFoundException($"Product with Id {id} not found.");
            }
            else
            {
                var product = _products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    throw new KeyNotFoundException($"Product with Id {id} not found.");
                }
                return Task.FromResult(product);
            }
        }

        public Task<Product> Update(Product product)
        {
            if (product == null) {
                throw new ArgumentNullException(nameof(product));
            }

            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with Id {product.Id} not found.");
            }

            existingProduct.Update(product.Kod, product.Nazwa, product.Cena);

            return Task.FromResult(existingProduct);
        }
    }
}
