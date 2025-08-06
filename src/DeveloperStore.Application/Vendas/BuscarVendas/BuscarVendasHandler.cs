using AutoMapper;
using DeveloperStore.Domain.Repositories;
using MediatR;
namespace DeveloperStore.Application.Vendas.BuscarVendas
{
    public class BuscarVendasHandler : IRequestHandler<BuscarVendasCommand, List<BuscarVendasResult>>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        public BuscarVendasHandler(IVendaRepository vendaRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        public async Task<List<BuscarVendasResult>> Handle(BuscarVendasCommand request, CancellationToken cancellationToken)
        {
            var vendas = await _vendaRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<BuscarVendasResult>>(vendas);
        }
    }
}
