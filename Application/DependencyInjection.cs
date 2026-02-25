using Application.Interfaces;
using Energigas.Api.Osinergmin.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPurchaseOrderService,PurchaseOrderService>();
            // Aquí puedes registrar tus servicios de aplicación, por ejemplo:
            // services.AddScoped<IMiServicio, MiServicio>();
            return services;
        }
    }
}
