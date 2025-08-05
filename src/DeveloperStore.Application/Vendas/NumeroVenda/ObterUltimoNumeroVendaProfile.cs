using AutoMapper;
using DeveloperStore.Application.DTO;
using DeveloperStore.Application.Vendas.BuscarVenda;
using DeveloperStore.Domain.Entities;

namespace DeveloperStore.Application.Vendas.NumeroVenda
{
    public class ObterUltimoNumeroVendaProfile: Profile
    {
        public ObterUltimoNumeroVendaProfile()
        {
            CreateMap<Venda, ObterUltimoNumeroVendaResult>();
        }
    }
}
