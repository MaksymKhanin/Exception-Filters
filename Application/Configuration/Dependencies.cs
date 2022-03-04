using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration
{
    public static class Dependencies
    {
        public static IServiceCollection AddValidationService(this IServiceCollection services)
            => services.AddTransient<IPayloadValidationService, PayloadValidationService>();
    }
}
