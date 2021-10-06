using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderOfWish.BLL.Concrete.DependencyInjection;
using OrderOfWish.UI.MVC.Models.Cart;
using System;
using OrderOfWish.UI.MVC.Helper;

namespace OrderOfWish.UI.MVC
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScopeBLL();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.Use((httpContext, nextMiddleware) =>
            {
                httpContext.Session.Set<MyCart>("cart", new MyCart());
                return nextMiddleware();
            });
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "defaul",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
