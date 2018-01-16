//using DoorsAn1.Data.interfaces;
//using DoorsAn1.Data.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DoorsAn1.Data;
//using DoorsAn1.Data.Repositories;
//using DoorsAn1.Data.Repositories;
using DoorsAn1.Data.Services.Repositories;
using DoorsAn1.Data.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DoorsAn1
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
            var key = Encoding.ASCII.GetBytes("super secret key");
            services.AddDbContext<AppDbContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddCors();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            /*services.AddIdentity<IdentityUser, IdentityRole>(opts => {
                opts.Password.RequiredLength = 5;   // минимальная длина
                opts.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                opts.Password.RequireLowercase = true; // требуются ли символы в нижнем регистре
                opts.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                opts.Password.RequireDigit = true; // требуются ли цифры
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();*/

            //services.AddTransient<IProductRepository, ProductRepository>();
            //services.AddTransient<ICategoryRepository, CategoryRepository>();
            
            //services.AddMemoryCache();
            //services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env/*, ILoggerFactory loggerFactory*/)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();

            //    // добавляем сборку через webpack
            //    /*app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
            //    {
            ///*loggerFactory.AddConsole();
            //    });*/
            //}
            /*app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();            
            app.UseSession();
            app.UseAuthentication();                      

            app.UseMvc(routes =>
            {
                routes.MapRoute("andrew", "andrew", new { controller = "Account", action = "Login" });
                routes.MapRoute(name: "categoryFilter", template: "Product/{action}/{category?}",
                    defaults:new {Controller="Product", action="List"});
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });*/

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseAuthentication();
            app.UseMvc();            
            
        }
    }
}
