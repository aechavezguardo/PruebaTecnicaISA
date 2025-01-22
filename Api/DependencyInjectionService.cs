using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Api
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration _configuration)
        {
            services.Configure<MongoSettings>(_configuration.GetSection("MongoSettings"));
            services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
                return new MongoClient(settings.ConnectionString);
            });

            services.AddSingleton<IMongoDatabase>(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
                return client.GetDatabase(settings.DatabaseName);
            });

            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<JwtService>();
            services.AddScoped<AuthService>();

            return services;
        }
    }
}
