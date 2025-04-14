using Services.Abstraction;
using Services;

namespace E_CommerceG01.Extentions
{
    public static class CoreServiceExtention
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection Services)
        {
            Services.AddScoped<IServiceManager, ServiceManager>();
            Services.AddAutoMapper(typeof(Services.AssemblyRefernce).Assembly);
            return Services;
        }
    }
}
