using AutoMapper;
using DeveloperStore.Application.Vendas.DeletarVenda;

namespace DeveloperStore.WebAPI.Features.Venda.DeletarVenda
{
    public class DeletarVendaProfile : Profile
    {
        public DeletarVendaProfile()
        {
            CreateMap<DeletarVendaRequest, DeletarVendaCommand>();
        }
    }
}
