using ProductCatalogApi.Application.Products.Commands;
using ProductCatalogApi.Repositories;

namespace ProductCatalogApi.Application.Products.Handlers
{
    public class DeleteProductCommandHandler
    {
        public readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }   

        public void Handle(DeleteProductCommand command)
        {
            _repository.Delete(command.Id);
        }
    }
}
