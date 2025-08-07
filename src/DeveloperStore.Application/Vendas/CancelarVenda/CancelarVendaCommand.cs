using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.CancelarVenda
{
    public class CancelarVendaCommand : IRequest<CancelarVendaResponse>
    {
        public int Id { get; set; }

        public CancelarVendaCommand(int id)
        {
            Id = id;
        }
    }
}
