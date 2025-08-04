using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.DeletarVenda
{
    public class DeletarVendaProfile : Profile
    {
        public DeletarVendaProfile()
        {
            CreateMap<DeletarVendaResult, DeletarVendaCommand>();
        }
    }
}
