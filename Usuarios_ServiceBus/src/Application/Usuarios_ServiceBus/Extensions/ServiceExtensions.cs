using Domain.Model.Interfaces;
using Domain.UseCase;
using DrivenAdapters.ServiceBus;
using DrivenAdapters.Sql.ApartamentoAdapter;
using DrivenAdapters.Sql.UsuarioAdapter;

namespace Usuarios_ServiceBus.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegistrarServicio(this IServiceCollection services)
        {
            #region UseCases

            services.AddScoped<IUsuarioUseCase, UsuarioUseCase>();
            services.AddScoped<IApartamentoUseCase, ApartamentoUseCase>();
            #endregion

            #region Adapters

            services.AddScoped<IAppServiceBus, AppServiceBus>();
            services.AddScoped<IUsuarioAdapter, UsuarioAdapter>();
            services.AddScoped<IApartamentoAdapter, ApartamentoAdapter>();
            #endregion
            return services;
        }
    }
}
