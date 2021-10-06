using Microsoft.Extensions.DependencyInjection;
using OrderOfWish.DAL.Abstract;
using OrderOfWish.DAL.Concrete.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.DAL.Concrete.DependencyInjection
{
   public static class EFContextDAL
    {
        public static void AddScopeDAL(this IServiceCollection services)
        {
            services.AddScoped<IBrandDAL, BrandRepository>();
            services.AddScoped<IGenreDAL, GenreRepository>();
            services.AddScoped<IOrderDAL, OrderRepository>();
            services.AddScoped<IUserDAL, UserRepository>();
            services.AddScoped<ISupplierDAL, SupplierRepository>();
            services.AddScoped<IProductDAL, ProductRepository>();
        }
    }
}
