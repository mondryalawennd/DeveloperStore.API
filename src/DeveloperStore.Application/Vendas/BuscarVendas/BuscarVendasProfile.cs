using AutoMapper;
using DeveloperStore.Application.DTO;
using DeveloperStore.Application.Vendas.BuscarVenda;
using DeveloperStore.Application.Vendas.CriarVenda;
using DeveloperStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.BuscarVendas
{
    public class BuscarVendasProfile : Profile
    {
        public BuscarVendasProfile()
        {
            CreateMap<ItemVendaDTO, ItemVenda>();
            CreateMap<ItemVenda, ItemVendaDTO>();

            CreateMap<Venda, BuscarVendasResult>();
            CreateMap<ItemVenda, ItensVendaResult>();
            CreateMap<ItemVenda, ItemVendaDTO>();
        }
    }
    }

