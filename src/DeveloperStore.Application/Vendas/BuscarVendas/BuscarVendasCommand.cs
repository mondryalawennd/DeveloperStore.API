using DeveloperStore.Application.Vendas.BuscarVenda;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.BuscarVendas
{
    public class BuscarVendasCommand : IRequest<List<BuscarVendasResult>>
    {
        // Sem parâmetros. Busca todas as vendas
    }
}
