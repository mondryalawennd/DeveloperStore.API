using AutoMapper;
using DeveloperStore.Domain.Entities;
using DeveloperStore.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.AlterarVenda
{
    public class AlterarVendaHandler : IRequestHandler<AlterarVendaCommand, AlterarVendaResult>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        public AlterarVendaHandler(IVendaRepository vendaRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        public async Task<AlterarVendaResult> Handle(AlterarVendaCommand request, CancellationToken cancellationToken)
        {
            var venda = await _vendaRepository.GetByIdAsync(request.Id);

            if (venda == null)
                return new AlterarVendaResult { Sucesso = false, Mensagem = "Venda não encontrada." };

            foreach (var itemDto in request.Itens)
            {
                venda.AdicionarItem(itemDto.ProdutoId, itemDto.Quantidade, itemDto.PrecoUnitario);
            }

            // Atualiza no banco de dados
            await _vendaRepository.UpdateAsync(venda);

            return new AlterarVendaResult
            {
                Id = venda.Id,
                NumeroVenda = venda.NumeroVenda,
                Sucesso = true,
                Mensagem = "Venda alterada com sucesso."
            };

        }
    }
}