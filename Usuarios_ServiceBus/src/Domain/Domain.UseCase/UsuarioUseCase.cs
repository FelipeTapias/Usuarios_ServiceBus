using Domain.Model.Entities;
using Domain.Model.Interfaces;

namespace Domain.UseCase
{
    public class UsuarioUseCase: IUsuarioUseCase
    {
        private readonly IAppServiceBus _appServiceBus;

        public UsuarioUseCase(IAppServiceBus appServiceBus)
        {
            _appServiceBus = appServiceBus;
        }

        public async Task<string> CreateSendMessage(Usuario usuario)
        {
            bool result = await _appServiceBus.SendMessage(usuario);
            if(!result)
            {
                return "Error al crear el Usuario";
            }

            return "Usuario creado éxitosamente";
        }

        public async Task CreateRecieveMessage()
        {
            await _appServiceBus.RecieveMessage();
        }
    }
}
