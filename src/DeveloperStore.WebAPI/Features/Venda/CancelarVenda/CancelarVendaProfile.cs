using AutoMapper;
using DeveloperStore.Application.Vendas.CancelarVenda;

namespace DeveloperStore.WebAPI.Features.Venda.CancelarVenda
{
    public class CancelarVendaProfile: Profile
    {
        public CancelarVendaProfile()
        {
            CreateMap<CancelarVendaRequest, CancelarVendaCommand>();
        }
    }
}
