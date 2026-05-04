using ProductCatalogApi.Models;
using ProductCatalogApi.Repositories;

namespace ProductCatalogApi.Application.Products.Commands
{
    public class CreateProductCommandHandler
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CreateProductCommand command)
        {
            var product = new Product
            {
                Kod = command.Kod,
                Nazwa = command.Nazwa,
                Cena = command.Cena
            };

            _repository.Add(product);
        }
    }
}