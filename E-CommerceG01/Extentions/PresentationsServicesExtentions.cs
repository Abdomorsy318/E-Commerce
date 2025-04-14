using Services.Abstraction;
using Services;
using E_CommerceG01.Factories;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceG01.Extentions
{
    public static class PresentationsServicesExtentions
    {
        public static IServiceCollection AddPresentation(this IServiceCollection Services)
        {
            Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
            Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.CustomeValidationError;
            });
            return Services;
        }
    }
}
