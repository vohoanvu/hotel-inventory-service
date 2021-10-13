using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ShopifyHotelSourcing.Repositories;
using ShopifyHotelSourcing.Repositories.Interfaces;
using ShopifyHotelSourcing.Services.HotelBedsService;
using ShopifyHotelSourcing.Services.HotelBedsService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopifyHotelSourcing", Version = "v1" });
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpClient<HotelAPIService>(c => c.BaseAddress = new Uri("https://api.test.hotelbeds.com"));

            services.AddDbContext<DBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlConnectionString")), ServiceLifetime.Singleton);

            services.AddScoped<IHotelAPIService, HotelAPIService>(); 
            services.AddSingleton<IUnitOfWork, UnitOfWork>();// change from Scoped to Singleton, to fix the re-usage of an already dispose context instance
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICountryRepository, CountryRepository>(); 
            services.AddScoped<IDestinationRepository, DestinationRepository>();

            services.AddScoped<ITravelLocationSevice, TravelLocationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopifyHotelSourcing v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
