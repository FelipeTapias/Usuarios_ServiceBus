using AutoMapper;
using Domain.Model.Entities;
using Domain.Model.Interfaces;
using DrivenAdapters.Sql.Context;
using Microsoft.EntityFrameworkCore;

namespace DrivenAdapters.Sql.ApartamentoAdapter
{
    public class ApartamentoAdapter: IApartamentoAdapter
    {
        private readonly UrbanizacionContext _context;
        private readonly IMapper _mapper;

        public ApartamentoAdapter(UrbanizacionContext context,
                                  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ApartamentoResponse>> GetAllApartamentos()
        {
            List<Apartamento> apartamentos = await _context.Apartamentos.ToListAsync();
            return _mapper.Map<List<ApartamentoResponse>>(apartamentos);
        }

        public async Task<ApartamentoResponse> GetApartamentoById(int id)
        {
            Apartamento? apartamento = await _context.Apartamentos.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ApartamentoResponse>(apartamento);
        }

        public async Task<ApartamentoRequest> PostApartamento(ApartamentoRequest apartamentoRequest)
        {
            Apartamento apartamento = _mapper.Map<Apartamento>(apartamentoRequest);
            await _context.Apartamentos.AddAsync(apartamento);
            await _context.SaveChangesAsync();
            return apartamentoRequest;
        }

        public async Task<ApartamentoResponse> PutApartamento(ApartamentoRequest apartamentoRequest, int id)
        {
            Apartamento apartamento = _mapper.Map<Apartamento>(apartamentoRequest);
            apartamento.Id = id;    
            _context.Update(apartamento);
            await _context.SaveChangesAsync();
            return _mapper.Map<ApartamentoResponse>(apartamento);
        }

        public async Task<ApartamentoResponse> DeleteApartamento(int id)
        {
            Apartamento? apartamento = await _context.Apartamentos.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(apartamento);
            await _context.SaveChangesAsync();
            return _mapper.Map<ApartamentoResponse>(apartamento);

        }
    }
}
