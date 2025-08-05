using AutoMapper;
using DeveloperStore.Application.DTO;
using DeveloperStore.Application.Produto.BuscarProdutos;
using DeveloperStore.Domain.Repositories;
using MediatR;

namespace DeveloperStore.Application.Produtos.BuscarProdutos
{
    public class BuscarProdutosHandle : IRequest<List<BuscarProdutosResult>>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public BuscarProdutosHandle(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<List<FilialDTO>> Handle(BuscarProdutosCommand request, CancellationToken cancellationToken)
        {
            var clientes = await _produtoRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<FilialDTO>>(clientes);
        }
    }
}