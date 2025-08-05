using AutoMapper;
using DeveloperStore.Application.Queries;

namespace DeveloperStore.WebAPI.Features.Venda.NumeroVenda
{
    public class ObterUltimoNumeroVendaProfile : Profile
    {
        public ObterUltimoNumeroVendaProfile()
        {
            CreateMap<ObterUltimoNumeroVendaResponse, ObterUltimoNumeroVendaQuery>();
        }
    }
}
