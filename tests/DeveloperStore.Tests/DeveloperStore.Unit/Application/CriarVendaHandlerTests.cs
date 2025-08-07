using AutoMapper;
using DeveloperStore.Application.Vendas.CriarVenda;
using DeveloperStore.Domain.Entities;
using DeveloperStore.Domain.Repositories;
using DeveloperStore.Tests.DeveloperStore.Unit.Application.TestData;
using NSubstitute;
using FluentAssertions;

namespace DeveloperStore.Tests.DeveloperStore.Unit.Application
{
    public class CriarVendaHandlerTests
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;
        private readonly CriarVendaHandler _handler;

        public CriarVendaHandlerTests()
        {
            _vendaRepository = Substitute.For<IVendaRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CriarVendaHandler(_vendaRepository, _mapper);
        }

        [Fact(DisplayName = "Dado um comando válido, quando criar venda, então retorna resultado com sucesso")]
        public async Task Handle_ComandoValido_DeveCriarVendaComSucesso()
        {
            // Arrange
            var command = CriarVendaHandlerTestData.GenerateValidCommand();

            var venda = new Venda(command.NumeroVenda, command.DataVenda, command.ClienteId, command.FilialId);
            foreach (var item in command.Itens)
            {
                venda.AdicionarItem(item.ProdutoId, item.Quantidade, item.PrecoUnitario);
            }

            var expectedResult = new CriarVendaResult
            {
                Id = 1,
                NumeroVenda = command.NumeroVenda,
                DataVenda = command.DataVenda,
                ClienteId = command.ClienteId,
                FilialId = command.FilialId,
                ValorTotal = command.ValorTotal,
                Cancelado = false
            };

            _mapper.Map<CriarVendaCommand, Venda>(command).Returns(venda);
            _mapper.Map<CriarVendaResult>(venda).Returns(expectedResult);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.NumeroVenda.Should().Be(command.NumeroVenda);
            result.ClienteId.Should().Be(command.ClienteId);

            await _vendaRepository.Received(1).AddAsync(Arg.Any<Venda>());
        }
    }
}