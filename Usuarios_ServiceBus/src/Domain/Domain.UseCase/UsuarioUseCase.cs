using Domain.Model.Entities;
using Domain.Model.Interfaces;

namespace Domain.UseCase
{
    public class UsuarioUseCase: IUsuarioUseCase
    {
        private readonly IAppServiceBus _appServiceBus;
        private readonly IUsuarioAdapter _usuarioAdapter;

        public UsuarioUseCase(IAppServiceBus appServiceBus,
                              IUsuarioAdapter usuarioAdapter)
        {
            _appServiceBus = appServiceBus;
            _usuarioAdapter = usuarioAdapter;
        }

        public async Task<string> CreateSendMessage(UsuarioRequest usuarioRequest)
        {
            bool result = await _appServiceBus.SendMessage(usuarioRequest);
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

        public async Task<List<UsuarioRequest>> GetAllUsers()
        {
            return await _usuarioAdapter.GetAllUser();
        }
    }
}
