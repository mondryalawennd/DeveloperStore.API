using AutoMapper;
using DeveloperStore.Application.DTO;
using DeveloperStore.Application.Vendas.BuscarVendas;
using Produto_ = DeveloperStore.Domain.Entities.Produto;

namespace DeveloperStore.Application.Produtos.BuscarProdutos
{
    public class BuscarProdutosProfile : Profile
    {

        public BuscarProdutosProfile()
        {
            CreateMap<Produto_, BuscarProdutosResult>();
            CreateMap<Produto_, ProdutoDTO>();

        }
    }
}
