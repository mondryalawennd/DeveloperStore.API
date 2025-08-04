using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.BuscarVenda
{
    public class BuscarVendaCommand : IRequest<BuscarVendaResult>
    {
        public int VendaId { get; set; }

        public BuscarVendaCommand(int vendaId)
        {
            VendaId = vendaId;
        }
    }
}
