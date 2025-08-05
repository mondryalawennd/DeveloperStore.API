using AutoMapper;
using DeveloperStore.Application.Vendas.BuscarVenda;
using DeveloperStore.Application.Vendas.BuscarVendas;

namespace DeveloperStore.WebAPI.Features.Venda.BuscarVenda
{
    public class BuscarVendaProfile : Profile
    {
        public BuscarVendaProfile()
        {
            CreateMap<BuscarVendaRequest, BuscarVendaCommand>()
                 .ConstructUsing(src => new BuscarVendaCommand(src.VendaId));

            CreateMap<BuscarVendaResult, BuscarVendaResponse>()
             .ForMember(dest => dest.ClienteNome, opt => opt.MapFrom(src => src.ClienteNome))
            .ForMember(dest => dest.FilialNome, opt => opt.MapFrom(src => src.FilialNome));

            CreateMap<ItemVendaResult, ItemVendaResponse>();

            CreateMap<BuscarVendasResult, BuscarVendaResponse>();
            CreateMap<ItensVendaResult, ItemVendaResponse>();


        }
    }
}