using Domain.Model.Entities;

namespace Domain.Model.Interfaces
{
    public interface IUsuarioAdapter
    {
        Task<List<UsuarioRequest>> GetAllUser();
    }
}
