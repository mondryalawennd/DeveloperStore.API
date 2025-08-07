using DeveloperStore.Domain.Entities;
using DeveloperStore.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.CancelarVenda
{
    public class CancelarVendaHandle : IRequestHandler<CancelarVendaCommand, CancelarVendaResponse>
    {
        private readonly IVendaRepository _vendaRepository;

        public CancelarVendaHandle(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<CancelarVendaResponse> Handle(CancelarVendaCommand request, CancellationToken cancellationToken)
        {
            var venda = await _vendaRepository.GetByIdAsync(request.Id);

            if (venda == null)
                return CancelarVendaResponse.Failure("Venda não encontrada.");


            venda.Cancelar();

            foreach (var item in venda.Itens)
            {
                item.Cancelar();
            }

            await _vendaRepository.UpdateAsync(venda);

            return CancelarVendaResponse.Success("Venda cancelada com sucesso.");
        }
    }
}