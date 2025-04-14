using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Presistance.Data;
using Presistance.Data.DataSeeding;

namespace E_CommerceG01.Extentions
{
    public static class InfraStructureServiceExtention
    {
        public static IServiceCollection AddInfraStructureService(this IServiceCollection Services , IConfiguration configuration)
        {
            Services.AddScoped<IDbIntializer, DbIntializer>();
            Services.AddScoped<IDbIntializer, DbIntializer>();
            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
            });
            return Services;
        }
    }
}
