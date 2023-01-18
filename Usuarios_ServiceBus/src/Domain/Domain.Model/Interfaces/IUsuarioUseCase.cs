using Domain.Model.Entities;

namespace Domain.Model.Interfaces
{
    public interface IUsuarioUseCase
    {
        Task<string> CreateSendMessage(Usuario usuario);

        Task CreateRecieveMessage();
    }
}
