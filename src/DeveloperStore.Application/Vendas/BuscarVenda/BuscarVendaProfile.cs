using AutoMapper;
using DeveloperStore.Application.DTO;
using DeveloperStore.Application.Vendas.CriarVenda;
using DeveloperStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.BuscarVenda
{
    public class BuscarVendaProfile : Profile
    {
        public BuscarVendaProfile()
        {
            CreateMap<ItemVendaDTO, ItemVenda>();
            CreateMap<ItemVenda, ItemVendaDTO>();

            CreateMap<Venda, BuscarVendaResult>();
            CreateMap<ItemVenda, ItemVendaResult>();
            CreateMap<ItemVenda, ItemVendaDTO>();
        }
    }
}
