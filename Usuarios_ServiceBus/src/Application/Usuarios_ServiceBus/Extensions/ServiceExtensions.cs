using Domain.Model.Interfaces;
using DrivenAdapters.ServiceBus;

namespace Usuarios_ServiceBus.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegistrarServicio(this IServiceCollection services)
        {
            services.AddScoped<IAppServiceBus, AppServiceBus>();
            return services;
        }
    }
}
