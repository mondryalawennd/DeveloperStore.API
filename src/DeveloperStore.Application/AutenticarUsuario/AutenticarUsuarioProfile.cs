using AutoMapper;
using DeveloperStore.Domain.Entities;

namespace DeveloperStore.Application.AutenticarUsuario
{
    public class AutenticarUsuarioProfile: Profile
    {
        public AutenticarUsuarioProfile()
        {
            CreateMap<Usuario, AutenticarUsuarioResult>()
                .ForMember(dest => dest.Token, opt => opt.Ignore())
                .ForMember(dest => dest.Papel, opt => opt.MapFrom(src => src.Papel.ToString()));
        }
    }
}
