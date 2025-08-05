
using MediatR;

namespace DeveloperStore.Application.Vendas.BuscarVendas
{
    public class BuscarVendasCommand : IRequest<List<BuscarVendasResult>>
    {
        // Sem parâmetros. Busca todas as vendas
    }
}
