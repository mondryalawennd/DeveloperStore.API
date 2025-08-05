using AutoMapper;
using DeveloperStore.Application.Produtos.BuscarProdutos;

namespace DeveloperStore.WebAPI.Features.Produto.BuscarProdutos
{
    public class BuscarProdutosProfile : Profile
    {
        public BuscarProdutosProfile()
        {
            CreateMap<BuscarProdutosResult, BuscarProdutosResponse>();
        }
    }
}

