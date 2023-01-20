using Domain.Model.Entities;

namespace Domain.Model.Interfaces
{
    public interface IApartamentoUseCase
    {
        Task<List<ApartamentoResponse>> GetAllApartamentos();
        Task<ApartamentoResponse> GetApartamentoById(int id);
        Task<ApartamentoRequest> PostApartamento(ApartamentoRequest apartamentoRequest);
        Task<ApartamentoResponse> PutApartamento(ApartamentoRequest apartamento, int id);
        Task<ApartamentoResponse> DeleteApartamento(int id);
    }
}
