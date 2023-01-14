using Domain.Model.Entities;

namespace Domain.Model.Interfaces
{
    public interface IAppServiceBus
    {
        Task SendMessage(Usuario usuario);
    }
}
