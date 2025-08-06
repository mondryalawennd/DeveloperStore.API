using AutoMapper;
using DeveloperStore.Application.Produto.BuscarProdutos;
using DeveloperStore.Application.Produtos.BuscarProdutos;

namespace DeveloperStore.WebAPI.Features.Produto.BuscarProdutos
{
    public class BuscarProdutosProfile : Profile
    {
        public BuscarProdutosProfile()
        {
            CreateMap<BuscarProdutosResponse, BuscarProdutosCommand>();
            CreateMap<BuscarProdutosResult, BuscarProdutosResponse>();
        }
    }
}

