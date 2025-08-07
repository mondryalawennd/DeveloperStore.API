using DeveloperStore.Application.Vendas.NumeroVenda;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Queries
{
    public class ObterUltimoNumeroVendaQuery: IRequest<ObterUltimoNumeroVendaResult>
    {
    }
}
