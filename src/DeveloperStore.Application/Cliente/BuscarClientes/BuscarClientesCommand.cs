
using MediatR;

namespace DeveloperStore.Application.Cliente.BuscarClientes
{
    public class BuscarClientesCommand : IRequest<List<BuscarClientesResult>>
    {
        // Sem parâmetros. Busca todos os clientes
    }
}
