using Application.Interfaces;
using Infrastructure.Integrations.Osinergmin;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<ISoapOsinergminClient, SoapOsinergminClient>();
            // Aquí puedes registrar tus servicios de aplicación, por ejemplo:
            // services.AddScoped<IMiServicio, MiServicio>();
            return services;
        }
    }
}
