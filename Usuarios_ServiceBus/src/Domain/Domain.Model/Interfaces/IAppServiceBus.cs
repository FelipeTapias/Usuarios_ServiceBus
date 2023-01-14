using Domain.Model.Entities;

namespace Domain.Model.Interfaces
{
    /// <summary>
    /// Interface IAppServiceBus
    /// </summary>
    public interface IAppServiceBus
    {
        /// <summary>
        /// Task SendMessage
        /// </summary>
        /// <param name="usuario"></param>
        Task SendMessage(Usuario usuario);

        /// <summary>
        /// Task RecieveMessage
        /// </summary>
        Task RecieveMessage();
    }
}
