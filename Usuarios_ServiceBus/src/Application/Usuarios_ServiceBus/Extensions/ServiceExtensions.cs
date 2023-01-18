using Domain.Model.Interfaces;
using Domain.UseCase;
using DrivenAdapters.ServiceBus;

namespace Usuarios_ServiceBus.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegistrarServicio(this IServiceCollection services)
        {
            services.AddScoped<IAppServiceBus, AppServiceBus>();
            services.AddScoped<IUsuarioUseCase, UsuarioUseCase>();
            return services;
        }
    }
}
