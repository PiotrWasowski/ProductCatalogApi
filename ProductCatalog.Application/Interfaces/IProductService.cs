using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetById(int id);
        Task<ProductDto> Create(CreateProductDto dto);
        Task Update(int id, CreateProductDto dto);
        Task Delete(int id); 
    }
}
