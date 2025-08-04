using AutoMapper;
using DeveloperStore.Application.DTO;
using DeveloperStore.Application.Vendas.AlterarVenda;
using DeveloperStore.Application.Vendas.CriarVenda;
using DeveloperStore.WebAPI.Features.CriarVenda;

namespace DeveloperStore.WebAPI.Features.AlterarVenda
{
    public class AlterarVendaProfile : Profile
    {
        public AlterarVendaProfile()
        {
            CreateMap<AlterarVendaRequest, AlterarVendaCommand>();
            CreateMap<ItemVendaRequest, ItemVendaDTO>();

            CreateMap<AlterarVendaResult, AlterarVendaResponse>()
        }
    }
}
