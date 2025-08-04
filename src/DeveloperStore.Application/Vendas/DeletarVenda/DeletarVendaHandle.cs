using AutoMapper;
using DeveloperStore.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.DeletarVenda
{
    public class DeletarVendaHandler : IRequestHandler<DeletarVendaCommand, DeletarVendaResult>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        public DeletarVendaHandler(IVendaRepository vendaRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        public async Task<DeletarVendaResult> Handle(DeletarVendaCommand request, CancellationToken cancellationToken)
        {
            var venda = await _vendaRepository.GetByIdAsync(request.Id);
            if (venda == null)
            {
                return new DeletarVendaResult
                {
                    Sucesso = false,
                    Mensagem = "Venda não encontrada."
                };
            }

            await _vendaRepository.DeleteAsync(venda.Id);

            return new DeletarVendaResult
            {
                Sucesso = true,
                Mensagem = "Venda deletada com sucesso."
            };
        }
    }
}
