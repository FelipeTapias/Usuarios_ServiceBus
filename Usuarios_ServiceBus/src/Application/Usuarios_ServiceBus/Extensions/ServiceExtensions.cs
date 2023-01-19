using Domain.Model.Interfaces;
using Domain.UseCase;
using DrivenAdapters.ServiceBus;
using DrivenAdapters.Sql.UsuarioAdapter;

namespace Usuarios_ServiceBus.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegistrarServicio(this IServiceCollection services)
        {
            #region UseCases

            services.AddScoped<IUsuarioUseCase, UsuarioUseCase>();
            #endregion

            #region Adapters

            services.AddScoped<IAppServiceBus, AppServiceBus>();
            services.AddScoped<IUsuarioAdapter, UsuarioAdapter>();
            #endregion
            return services;
        }
    }
}
