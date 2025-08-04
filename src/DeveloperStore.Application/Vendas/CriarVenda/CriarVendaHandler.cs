using AutoMapper;
using DeveloperStore.Domain.Entities;
using DeveloperStore.Domain.Events;
using DeveloperStore.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.CriarVenda
{
    public class CriarVendaHandler : IRequestHandler<CriarVendaCommand, CriarVendaResult>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        public CriarVendaHandler(IVendaRepository vendaRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        public async Task<CriarVendaResult> Handle(CriarVendaCommand request, CancellationToken cancellationToken)
        {
            var itens = new List<ItemVenda>();

            var dataVendaUtc = request.DataVenda.Kind == DateTimeKind.Utc
                ? request.DataVenda
                : request.DataVenda.ToUniversalTime();

            var venda = new Venda(
                    numeroVenda: request.NumeroVenda,
                    dataVenda: dataVendaUtc,
                    clienteId: request.ClienteId,
                    filialId: request.FilialId
                );

            foreach (var itemDto in request.Itens)
            {
                venda.AdicionarItem(itemDto.ProdutoId, itemDto.Quantidade, itemDto.PrecoUnitario);
            }

            await _vendaRepository.AddAsync(venda);

            // Retorna o mapeamento da entidade venda para o resultado
            return _mapper.Map<CriarVendaResult>(venda);
        }

    }
}