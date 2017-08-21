using System;
using DoorsAn1.Data.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DoorsAn1.Data;
using DoorsAn1.Data.Models;
using DoorsAn1.Data.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DoorsAn1
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
              

            // Add Database Initializer
            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IDbInitializer dbInitializer)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseIdentity();

            //dbInitializer.Initialize();

            app.UseMvc(routes =>
            {
                routes.MapRoute("andrew", "andrew", new { controller = "Account", action = "Login" });
                routes.MapRoute(name: "categoryFilter", template: "Product/{action}/{category?}",
                    defaults:new {Controller="Product", action="List"});
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }
    }
}
