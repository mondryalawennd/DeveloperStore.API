using AutoMapper;
using DeveloperStore.Application.DTO;
using DeveloperStore.Domain.Entities;

namespace DeveloperStore.Application.Vendas.CriarVenda
{
    public class CriarVendaProfile : Profile
    {
        public CriarVendaProfile()
        {
            CreateMap<CriarVendaCommand, Venda>()
            .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Itens));

            CreateMap<ItemVendaDTO, ItemVenda>();
            CreateMap<ItemVenda, ItemVendaDTO>();

            CreateMap<Venda, CriarVendaResult>();
            CreateMap<ItemVenda, ItemVendaDTO>();
        }
    }
}
