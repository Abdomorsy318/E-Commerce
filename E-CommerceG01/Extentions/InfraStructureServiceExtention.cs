using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Presistance.Data;
using Presistance.Data.DataSeeding;
using Presistance.Reposatories;
using StackExchange.Redis;

namespace E_CommerceG01.Extentions
{
    public static class InfraStructureServiceExtention
    {
        public static IServiceCollection AddInfraStructureService(this IServiceCollection Services , IConfiguration configuration)
        {
            Services.AddScoped<IDbIntializer, DbIntializer>();
            Services.AddScoped<IUniteOfWork, UniteOfWork>();
            Services.AddScoped<IBasketReposatory, BasketReposatory>();
            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
            });
            Services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")));
            return Services;
        }
    }
}
