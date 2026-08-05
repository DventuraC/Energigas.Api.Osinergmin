using Application.Interfaces;
using Infrastructure.Configuration;
using Infrastructure.Integrations.Osinergmin;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddScoped<ISoapOsinergminClient, SoapOsinergminClient>();

            var osinergminOptions = configuration.GetSection("OsinergminSettings").Get<OsinergminOptions>();

            services.AddHttpClient("OsinergminConfig", client =>
            {
                if (osinergminOptions?.Domain == null)
                {
                    throw new ArgumentNullException(nameof(osinergminOptions.Domain), "La URL del servicio EnergigasFacturacion no puede ser nula.");
                }

                client.BaseAddress = new Uri(osinergminOptions.Domain);
            });

            return services;
        }
    }
}
