using AutoMapper;
using Domain.Model.Entities;
using Domain.Model.Interfaces;
using DrivenAdapters.Sql.Context;
using Microsoft.EntityFrameworkCore;

namespace DrivenAdapters.Sql.UsuarioAdapter
{
    public class UsuarioAdapter : IUsuarioAdapter
    {
        private readonly UrbanizacionContext _context;
        private readonly IMapper _mapper;

        public UsuarioAdapter(UrbanizacionContext context,
                              IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UsuarioRequest>> GetAllUser()
        {
            List<Usuario> usuarios = await _context.Usuarios.Include(x => x.IdApartamentoNavigation).ToListAsync();
            return _mapper.Map<List<UsuarioRequest>>(usuarios);
        }
    }
}
