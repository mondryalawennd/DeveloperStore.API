using AutoMapper;
using DeveloperStore.Application.Filial.BuscarFiliais;
using DeveloperStore.WebAPI.Common;
using DeveloperStore.WebAPI.Features.Filial.BuscarFiliais;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.WebAPI.Features
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilialController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FilialController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("BuscarFiliais")]
        public async Task<IActionResult> BuscarFiliais(CancellationToken cancellationToken)
        {
            var command = new BuscarFiliaisCommand();
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<List<BuscarFiliaisResponse>>
            {
                Success = true,
                Message = "Clientes recuperados com sucesso",
                Data = _mapper.Map<List<BuscarFiliaisResponse>>(result)
            });
        }
    }
}
