using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.NumeroVenda
{
    public class ObterUltimoNumeroVendaCommand : IRequest<ObterUltimoNumeroVendaResult>
    {
        public string NumeroVenda { get; set; }

        public ObterUltimoNumeroVendaCommand(string numeroVenda)
        {
            NumeroVenda = numeroVenda;
        }
    }
}

