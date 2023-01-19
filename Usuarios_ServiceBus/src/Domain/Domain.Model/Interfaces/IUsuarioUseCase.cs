using Domain.Model.Entities;

namespace Domain.Model.Interfaces
{
    public interface IUsuarioUseCase
    {
        Task<string> CreateSendMessage(UsuarioRequest usuario);

        Task CreateRecieveMessage();

        Task<List<UsuarioRequest>> GetAllUsers();
    }
}
