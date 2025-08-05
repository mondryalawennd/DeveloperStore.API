using AutoMapper;
using DeveloperStore.Application.DTO;
using DeveloperStore.Domain.Repositories;
using MediatR;

namespace DeveloperStore.Application.Filial.BuscarFiliais
{
    public class BuscarFiliaisHandle : IRequest<List<BuscarFiliaisResult>>
    {

        private readonly IFilialRepository _filialRepository;
        private readonly IMapper _mapper; 
        
        public BuscarFiliaisHandle(IFilialRepository filialRepository, IMapper mapper)
        {
            _filialRepository = filialRepository;
            _mapper = mapper;
        }

        public async Task<List<FilialDTO>> Handle(BuscarFiliaisCommand request, CancellationToken cancellationToken)
        {
            var clientes = await _filialRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<FilialDTO>>(clientes);
        }
    }
}