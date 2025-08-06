using AutoMapper;
using DeveloperStore.Application.DTO;
using DeveloperStore.Application.Cliente.BuscarClientes;
namespace DeveloperStore.WebAPI.Features.Cliente.BuscarClientes
{
    public class BuscarClientesProfile : Profile
    {
        public BuscarClientesProfile()
        {
            CreateMap<BuscarClientesResult, BuscarClientesResponse>();
        }

    }
}