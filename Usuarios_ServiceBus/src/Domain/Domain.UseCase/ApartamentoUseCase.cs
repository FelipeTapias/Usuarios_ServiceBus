using Domain.Model.Entities;
using Domain.Model.Interfaces;

namespace Domain.UseCase
{
    public class ApartamentoUseCase: IApartamentoUseCase
    {
        private readonly IApartamentoAdapter _apartamentoAdapter;

        public ApartamentoUseCase(IApartamentoAdapter apartamentoAdapter)
        {
            _apartamentoAdapter = apartamentoAdapter;
        }

        public async Task<List<ApartamentoResponse>> GetAllApartamentos()
        {
            return await _apartamentoAdapter.GetAllApartamentos();
        }

        public async Task<ApartamentoResponse> GetApartamentoById(int id)
        {
            return await _apartamentoAdapter.GetApartamentoById(id);
        }

        public async Task<ApartamentoRequest> PostApartamento(ApartamentoRequest apartamentoRequest)
        {
            return await _apartamentoAdapter.PostApartamento(apartamentoRequest);
        }

        public async Task<ApartamentoResponse> PutApartamento(ApartamentoRequest apartamento, int id)
        {
            return await _apartamentoAdapter.PutApartamento(apartamento, id);
        }

        public async Task<ApartamentoResponse> DeleteApartamento(int id)
        {
            return await _apartamentoAdapter.DeleteApartamento(id);
        }


    }
}
