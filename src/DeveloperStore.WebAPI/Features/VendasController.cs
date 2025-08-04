using AutoMapper;
using DeveloperStore.Application.Vendas.AlterarVenda;
using DeveloperStore.Application.Vendas.BuscarVenda;
using DeveloperStore.Application.Vendas.BuscarVendas;
using DeveloperStore.Application.Vendas.CriarVenda;
using DeveloperStore.Common.Validation;
using DeveloperStore.WebAPI.Common;
using DeveloperStore.WebAPI.Features.BuscarVenda;
using DeveloperStore.WebAPI.Features.CriarVenda;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.WebAPI.Features
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public VendasController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("CriarVenda")]
        [ProducesResponseType(typeof(ApiResponseWithData<CriarVendaResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarVenda([FromBody] CriarVendaRequest request, CancellationToken cancellationToken)
        {
            var validator = new CriarVendaRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorResponse = new ApiResponse
                {
                    Success = false,
                    Message = "Erro de validação",
                    Errors = validationResult.Errors.Select(e => new ValidationErrorDetail
                    {
                        Error = e.PropertyName,
                        Detail = e.ErrorMessage
                    })
                };

                return BadRequest(errorResponse);
            }

            var command = _mapper.Map<CriarVendaCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CriarVendaResult>
            {
                Success = true,
                Message = "Venda criada com sucesso",
                Data = _mapper.Map<CriarVendaResult>(result)
            });
        }


        [HttpGet("BuscarVenda/{id}")]
        public async Task<IActionResult> BuscarVenda([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new BuscarVendaRequest { VendaId = id };
            var validator = new BuscarVendaRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorResponse = new ApiResponse
                {
                    Success = false,
                    Message = "Erro de validação",
                    Errors = validationResult.Errors.Select(e => new ValidationErrorDetail
                    {
                        Error = e.PropertyName,
                        Detail = e.ErrorMessage
                    })
                };

                return BadRequest(errorResponse);
            }

            var command = _mapper.Map<BuscarVendaCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);

            if (result == null)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Venda não encontrada"
                });
            }

            return Ok(new ApiResponseWithData<BuscarVendaResponse>
            {
                Success = true,
                Message = "Venda encontrada com sucesso",
                Data = _mapper.Map<BuscarVendaResponse>(result)
            });
        }

        [HttpGet("BuscarVendas")]
        public async Task<IActionResult> BuscarVendas(CancellationToken cancellationToken)
        {
            var command = new BuscarVendasCommand();
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<List<BuscarVendaResponse>>
            {
                Success = true,
                Message = "Vendas recuperadas com sucesso",
                Data = _mapper.Map<List<BuscarVendaResponse>>(result)
            });
        }


        [HttpPut("AlterarVenda")]
        public async Task<IActionResult> AlterarVenda([FromBody] AlterarVendaCommand command, CancellationToken cancellationToken)
        {
            if (command == null || command.Itens == null || !command.Itens.Any())
            {
                return BadRequest("Dados da venda ou itens inválidos.");
            }

            var result = await _mediator.Send(command, cancellationToken);

            if (!result.Sucesso)
                return BadRequest(result.Mensagem);

            return Ok(result);
        }

    }
}
