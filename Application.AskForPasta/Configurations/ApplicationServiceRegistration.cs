using Application.AskForPasta.Features;
using Application.AskForPasta.Interfaces.Features;
using Microsoft.Extensions.DependencyInjection;

namespace Application.AskForPasta.Configurations
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginWorkFlowFeature, LoginWorkFlowFeature>();
            services.AddScoped<IProductFeature, ProductFeature>();
            services.AddScoped<IAddressFeature, AddressFeature>();

            return services;
        }
    }
}
