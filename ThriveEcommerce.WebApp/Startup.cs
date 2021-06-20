using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.BusinessLibrary.Interfaces;
using ThriveEcommerce.BusinessLibrary.Services;
using ThriveEcommerce.Data.Data;
using ThriveEcommerce.Data.Logging;
using ThriveEcommerce.Data.Repository;
using ThriveEcommerce.Data.Repository.Base;
using ThriveEcommerce.Domain.Configuration;
using ThriveEcommerce.Domain.Interfaces;
using ThriveEcommerce.Domain.Repositories;
using ThriveEcommerce.Domain.Repositories.Base;
using ThriveEcommerce.WebApp.HealthChecks;
using ThriveEcommerce.WebApp.Interfaces;
using ThriveEcommerce.WebApp.Services;

namespace ThriveEcommerce.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureThriveEcommerceServices(services);


            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddRazorPages();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }


        public void ConfigureDatabases(IServiceCollection services)
        {
          /// services.AddDbContext<ThriveEcommerceContext>(c => c.UseInMemoryDatabase("ThriveEcommerceConnection"));
        }

        public void ConfigureIdentity(IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ThriveEcommerceContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
        }


        private void ConfigureThriveEcommerceServices(IServiceCollection services)
        {
            // Add Core Layer
            services.Configure<ThriveEcommerceSettings>(Configuration);

            // Add Infrastructure Layer
            ConfigureDatabases(services);
            ConfigureIdentity(services);

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IWishlistRepository, WishlistRepository>();
            services.AddScoped<ICompareRepository, CompareRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();


            // Add Application Layer
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IWishlistService, WishListService>();
            services.AddScoped<ICompareService, CompareService>();
            services.AddScoped<IOrderService, OrderService>();

           
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IIndexPageService, IndexPageService>();
            services.AddScoped<IProductPageService, ProductPageService>();
            services.AddScoped<ICategoryPageService, CategoryPageService>();
            services.AddScoped<ICartComponentService, CartComponentService>();
            services.AddScoped<IWishlistPageService, WishlistPageService>();
            services.AddScoped<IComparePageService, ComparePageService>();
            services.AddScoped<ICheckOutPageService, CheckOutPageService>();

            services.AddHttpContextAccessor();
            services.AddHealthChecks().AddCheck<IndexPageHealthCheck>("home_page_health_check");
        }

    }
}
