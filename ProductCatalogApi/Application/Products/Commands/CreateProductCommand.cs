using ProductCatalogApi.Models;

namespace ProductCatalogApi.Application.Products.Commands
{
    public class CreateProductCommand
    {
        public string Kod { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
    }
}
