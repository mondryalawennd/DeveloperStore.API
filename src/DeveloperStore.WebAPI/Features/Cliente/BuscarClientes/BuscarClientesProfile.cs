using DeveloperStore.Application.Cliente.BuscarClientes;
using AutoMapper;
using DeveloperStore.Application.Vendas.BuscarVenda;

namespace DeveloperStore.WebAPI.Features.Cliente.BuscarClientes
{
    public class BuscarClientesProfile : Profile
    {
        public BuscarClientesProfile()
        {
            CreateMap<BuscarVendaResult, BuscarClientesResponse>();
        }

    }
}