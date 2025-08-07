using AutoMapper;
using Usuarios = DeveloperStore.Domain.Entities.Usuario;

namespace DeveloperStore.WebAPI.Features.Usuario
{
    public class AutenticarUsuarioProfile : Profile
    {
        public AutenticarUsuarioProfile()
        {
            CreateMap<Usuarios, AutenticarUsuarioResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore())
                .ForMember(dest => dest.Papel, opt => opt.MapFrom(src => src.Papel.ToString()));
        }
    }
}
