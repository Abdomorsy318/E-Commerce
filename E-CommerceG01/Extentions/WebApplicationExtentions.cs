using Domain.Contracts;
using E_CommerceG01.Middelwares;

namespace E_CommerceG01.Extentions
{
    public static class WebApplicationExtentions
    {
        public static async Task<WebApplication> SeedDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbIntializer = services.GetRequiredService<IDbIntializer>();
            await dbIntializer.IntializeAsync();
            return app;
        }
        public static WebApplication UseCustomeMiddelwareExceptions(this WebApplication app)
        {
            app.UseMiddleware<GlobalExceptionHandlingMiddelware>();
            return app;
        }
        
    }
}
