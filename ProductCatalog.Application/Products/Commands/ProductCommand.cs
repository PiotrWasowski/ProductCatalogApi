using MediatR;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Products.Commands
{
    public abstract class ProductCommand: IRequest<Product>
    {
        public string Kod { get; set; }

        public string Nazwa { get; set; }

        public decimal Cena { get; set; }
    }
}
