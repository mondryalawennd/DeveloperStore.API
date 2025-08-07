using AutoMapper;
using DeveloperStore.Application.AutenticarUsuario;
using DeveloperStore.WebAPI.Common;
using DeveloperStore.WebAPI.Features.Usuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.WebAPI.Features
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsuarioController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("AuthenticateUserRequest/{id}")]
        public async Task<IActionResult> AutenticarUsuario([FromBody] AutenticarUsuarioRequest request, CancellationToken cancellationToken)
        {
            var validator = new AutenticarUsuarioRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<AutenticarUsuarioCommon>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<AutenticarUsuarioResponse>
            {
                Success = true,
                Message = "Usuário autenticado com sucesso",
                Data = _mapper.Map<AutenticarUsuarioResponse>(response)
            });
        }
    }
}