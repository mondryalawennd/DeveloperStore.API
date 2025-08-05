using AutoMapper;
using DeveloperStore.Application.Filial.BuscarFiliais;

namespace DeveloperStore.WebAPI.Features.Filial.BuscarFiliais
{
    public class BuscarFiliaisProfile : Profile
    {
        public BuscarFiliaisProfile()
        {
            CreateMap<BuscarFiliaisResult, BuscarFiliaisResponse>();
        }
    }
}
