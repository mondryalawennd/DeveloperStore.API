using AutoMapper;
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
            return _mapper.Map<BuscarVendaResult>(venda);
        }
    }
}
