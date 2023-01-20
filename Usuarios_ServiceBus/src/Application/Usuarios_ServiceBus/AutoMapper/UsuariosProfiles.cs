using AutoMapper;
using Domain.Model.Entities;
using DrivenAdapters.Sql.Context;

namespace Usuarios_ServiceBus.AutoMapper
{
    public class UsuariosProfiles: Profile
    {
        public UsuariosProfiles()
        {
            CreateMap<Usuario, UsuarioRequest>().ForMember(x => x.ApartamentoRequest, x => x.MapFrom(x => x.IdApartamentoNavigation));
            CreateMap<Apartamento, ApartamentoResponse>();
            CreateMap<ApartamentoRequest, Apartamento>();
        }
    }
}
