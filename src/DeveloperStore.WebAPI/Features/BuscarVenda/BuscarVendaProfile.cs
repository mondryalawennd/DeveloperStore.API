using AutoMapper;
using DeveloperStore.Application.DTO;
using DeveloperStore.Application.Vendas.BuscarVenda;
using DeveloperStore.Application.Vendas.BuscarVendas;
using DeveloperStore.WebAPI.Features.CriarVenda;

namespace DeveloperStore.WebAPI.Features.BuscarVenda
{
    public class BuscarVendaProfile : Profile
    {
        public BuscarVendaProfile()
        {
            CreateMap<BuscarVendaRequest, BuscarVendaCommand>()
                 .ConstructUsing(src => new BuscarVendaCommand(src.VendaId));

            CreateMap<BuscarVendaResult, BuscarVendaResponse>();
            CreateMap<ItemVendaResult, ItemVendaResponse>();

            CreateMap<BuscarVendasResult, BuscarVendaResponse>();
            CreateMap<ItensVendaResult, ItemVendaResponse>();

        }
    }
}