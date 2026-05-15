using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ProductCatalog.Domain.Interfaces;
using ProductCatalog.Infrastructure.Repositories.Products.Memory;

namespace ProductCatalog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IProductRepository, InMemoryProductRepository>();
            return services;
        }
    }
}
