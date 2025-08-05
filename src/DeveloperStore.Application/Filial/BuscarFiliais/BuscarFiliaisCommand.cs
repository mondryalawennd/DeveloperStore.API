
using MediatR;

namespace DeveloperStore.Application.Filial.BuscarFiliais
{
    public class BuscarFiliaisCommand : IRequest<List<BuscarFiliaisResult>>
    {
        // Sem parâmetros. Busca todas as filiais
    }
}
