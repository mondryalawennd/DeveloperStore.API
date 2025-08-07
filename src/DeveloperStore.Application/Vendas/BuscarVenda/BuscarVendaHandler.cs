using AutoMapper;
using DeveloperStore.Application.DTO;
using DeveloperStore.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.BuscarVenda
{
    public class BuscarVendaHandler : IRequestHandler<BuscarVendaCommand, BuscarVendaResult>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        public BuscarVendaHandler(IVendaRepository vendaRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        public async Task<BuscarVendaResult> Handle(BuscarVendaCommand request, CancellationToken cancellationToken)
        {
            var venda = await _vendaRepository.GetByIdAsync(request.VendaId);
            if (venda == null)
                return null;

            return new BuscarVendaResult
            {
                Id = venda.Id,
                NumeroVenda = venda.NumeroVenda,
                ClienteId = venda.ClienteId,
                FilialId = venda.FilialId,
                DataVenda = venda.DataVenda,
                ValorTotal = venda.ValorTotal, 
                Cancelado = venda.Cancelado,
                Itens = venda.Itens.Select(i => new ItemVendaResult
                {
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade,
                    PrecoUnitario = i.PrecoUnitario,
                    Desconto = i.Desconto,
                    Cancelado = i.Cancelado
                }).ToList()
            };
        }
    }
}