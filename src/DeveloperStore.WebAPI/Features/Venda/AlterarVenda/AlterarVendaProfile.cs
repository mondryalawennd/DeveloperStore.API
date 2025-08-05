using AutoMapper;
using DeveloperStore.Application.DTO;
using DeveloperStore.Application.Vendas.AlterarVenda;
using DeveloperStore.Application.Vendas.CriarVenda;
using DeveloperStore.WebAPI.Features.Venda.CriarVenda;

namespace DeveloperStore.WebAPI.Features.Venda.AlterarVenda
{
    public class AlterarVendaProfile : Profile
    {
        public AlterarVendaProfile()
        {
            CreateMap<AlterarVendaRequest, AlterarVendaCommand>();
            CreateMap<ItemVendaRequest, ItemVendaDTO>();

            CreateMap<AlterarVendaResult, AlterarVendaResponse>();
        }
    }
}
