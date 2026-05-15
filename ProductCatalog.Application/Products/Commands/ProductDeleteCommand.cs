using MediatR;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Products.Commands
{
    public class ProductDeleteCommand: IRequest<Product>
    {
        public int Id { get; set; }

        public ProductDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
