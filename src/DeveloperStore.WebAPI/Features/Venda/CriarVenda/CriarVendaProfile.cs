using AutoMapper;
using DeveloperStore.Application.DTO;
using DeveloperStore.Application.Vendas.CriarVenda;
using DeveloperStore.Domain.Entities;

namespace DeveloperStore.WebAPI.Features.Venda.CriarVenda
{
    public class CriarVendaProfile : Profile
    {
        public CriarVendaProfile()
        {
            CreateMap<CriarVendaRequest, CriarVendaCommand>();
            CreateMap<ItemVendaRequest, ItemVendaDTO>();
        }


    }
}