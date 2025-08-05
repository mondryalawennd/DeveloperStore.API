using DeveloperStore.Application.Produtos.BuscarProdutos;
using MediatR;

namespace DeveloperStore.Application.Produto.BuscarProdutos
{
    public class BuscarProdutosCommand : IRequest<List<BuscarProdutosResult>>
    { 
        // Sem parâmetros. Busca todos os Produtos
    }
}
