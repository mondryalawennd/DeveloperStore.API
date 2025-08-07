using AutoMapper;
using DeveloperStore.Domain.Repositories;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.DeletarVenda
{
    public class DeletarVendaHandler : IRequestHandler<DeletarVendaCommand, DeletarVendaResponse>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        public DeletarVendaHandler(IVendaRepository vendaRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        public async Task<DeletarVendaResponse> Handle(DeletarVendaCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeletarVendaValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var retorno = await _vendaRepository.DeleteAsync(request.Id);

            if (!retorno)
                throw new KeyNotFoundException($"Venda ID {request.Id} não encontrada.");

           
            return new DeletarVendaResponse
            {
                Sucesso = true,
                Mensagem = "Venda deletada com sucesso."
            };
        }
    }
}
