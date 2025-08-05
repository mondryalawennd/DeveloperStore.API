using AutoMapper;
using DeveloperStore.Application.Produto.BuscarProdutos;
using DeveloperStore.WebAPI.Common;
using DeveloperStore.WebAPI.Features.Produto.BuscarProdutos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.WebAPI.Features
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProdutoController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarProdutos(CancellationToken cancellationToken)
        {
            var command = new BuscarProdutosCommand();
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<List<BuscarProdutosResponse>>
            {
                Success = true,
                Message = "Produtos recuperados com sucesso",
                Data = _mapper.Map<List<BuscarProdutosResponse>>(result)
            });
        }
    }
}
