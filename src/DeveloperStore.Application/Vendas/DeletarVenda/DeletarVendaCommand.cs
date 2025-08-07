using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.DeletarVenda
{
    public class DeletarVendaCommand : IRequest<DeletarVendaResponse>
    {
        public int Id { get; set; }

        public DeletarVendaCommand(int id)
        {
            Id = id;
        }
    }
}
