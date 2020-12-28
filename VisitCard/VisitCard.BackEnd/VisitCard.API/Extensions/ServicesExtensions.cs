using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using VisitCard.BLL.Services;
using VisitCard.BLL.Services.Interfaces;
using VisitCard.DAL;
using VisitCard.DAL.Context;
using VisitCard.DAL.Interfaces;
using VisitCard.DAL.Repository;

namespace VisitCard.API.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureDi(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryManager, RepositoryManager>();
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<ICardService, CardService>();
        }

        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder
                        .WithOrigins(configuration["WebUrl"])
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }
        
        public static void ConfigureSwagger(this IServiceCollection services) 
        {
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "VisitCard", Version = "v1"}));
        }
    }
}