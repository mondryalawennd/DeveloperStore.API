using AutoMapper;
using DeveloperStore.Application.Cliente.BuscarClientes;
using DeveloperStore.WebAPI.Common;
using DeveloperStore.WebAPI.Features.Cliente.BuscarClientes;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.WebAPI.Features
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ClienteController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> BuscarClientes(CancellationToken cancellationToken)
        {
            var command = new BuscarClientesCommand();
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<List<BuscarClientesResponse>>
            {
                Success = true,
                Message = "Clientes recuperados com sucesso",
                Data = _mapper.Map<List<BuscarClientesResponse>>(result)
            });
        }
    }
}
