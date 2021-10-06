using Microsoft.Extensions.DependencyInjection;
using OrderOfWish.BLL.Abstract;
using OrderOfWish.DAL.Concrete.DependencyInjection;

namespace OrderOfWish.BLL.Concrete.DependencyInjection
{
    public static class EFContextBLL
    {
        public static void AddScopeBLL(this IServiceCollection services)
        {
            services.AddScopeDAL();
            services.AddScoped<IBrandBLL, BrandService>();
            services.AddScoped<IGenreBLL, GenreService>();
            services.AddScoped<IOrderBLL, OrderService>();
            services.AddScoped<ISupplierBLL, SupplierService>();
            services.AddScoped<IUserBLL, UserService>();
            services.AddScoped<IProductBLL, ProductService>();
        }
    }
}
