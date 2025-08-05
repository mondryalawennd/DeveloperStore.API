
using AutoMapper;
using DeveloperStore.Application.DTO;
using DeveloperStore.Domain.Repositories;
using MediatR;

namespace DeveloperStore.Application.Cliente.BuscarClientes
{
    public class BuscarClientesHandle : IRequest<List<BuscarClientesResult>>
    {
       
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public BuscarClientesHandle(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<List<ClienteDTO>> Handle(BuscarClientesCommand request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<ClienteDTO>>(clientes);
        }
    }
}