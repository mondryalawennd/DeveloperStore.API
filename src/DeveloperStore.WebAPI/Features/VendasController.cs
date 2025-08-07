using AutoMapper;
using DeveloperStore.Application.Queries;
using DeveloperStore.Application.Vendas.AlterarVenda;
using DeveloperStore.Application.Vendas.BuscarVenda;
using DeveloperStore.Application.Vendas.BuscarVendas;
using DeveloperStore.Application.Vendas.CancelarVenda;
using DeveloperStore.Application.Vendas.CriarVenda;
using DeveloperStore.Application.Vendas.DeletarVenda;
using DeveloperStore.Common.Validation;
using DeveloperStore.WebAPI.Common;
using DeveloperStore.WebAPI.Features.Venda.BuscarVenda;
using DeveloperStore.WebAPI.Features.Venda.CancelarVenda;
using DeveloperStore.WebAPI.Features.Venda.CriarVenda;
using DeveloperStore.WebAPI.Features.Venda.DeletarVenda;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

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
       
        //[Authorize]
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

        //[Authorize]
        [HttpPut("AlterarVenda/{id}")]
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

        //[Authorize]
        [HttpDelete("DeletarVenda/{id}")]
        public async Task<IActionResult> DeletarVenda(int id, CancellationToken cancellationToken)
        {
            var request = new DeletarVendaRequest { Id = id };
            var validator = new DeletarVendaRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeletarVendaCommand>(request.Id);
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Venda apagada com sucesso"
            });
        }

        [HttpPut("CancelarVenda/{id}")]
        public async Task<IActionResult> CancelarVenda(int id, CancellationToken cancellationToken)
        {
            var request = new CancelarVendaRequest { Id = id };
            var command = _mapper.Map<CancelarVendaCommand>(request.Id);
            var result = await _mediator.Send(command, cancellationToken);

            if (!result.Sucesso)
                return BadRequest(result.Mensagem);

            return Ok(result);
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
              //  Message = "Venda encontrada com sucesso",
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

        [HttpGet("ObterUltimoNumeroVenda")]
        public async Task<IActionResult> ObterUltimoNumeroVenda()
        {
            var query = new ObterUltimoNumeroVendaQuery();
            var result = await _mediator.Send(query);
            return Ok(new { data = result.NumeroVenda });
        }


    }
}
