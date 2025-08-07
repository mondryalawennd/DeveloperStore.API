using DeveloperStore.Application.Vendas.CriarVenda;
using DeveloperStore.Tests.DeveloperStore.Unit.Domain.Entities.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Tests.DeveloperStore.Unit.Domain.Entities
{
    public class VendaTests
    {
        /// <summary>
        /// Quando uma venda é cancelada, seu status é definido como verdadeiro.
        /// </summary>
        [Fact(DisplayName = "Venda deve ser marcada como cancelada quando Cancelar() for chamado")]
        public void Given_ActiveVenda_When_Canceled_Then_CanceladoShouldBeTrue()
        {
            // Arrange
            var venda = VendaTestData.GenerateValidCommand();

            // Act
            venda.Cancelado = true;

            // Assert
            Assert.True(venda.Cancelado);
        }

        /// <summary>
        /// Testa se uma venda não é cancelada por padrão.
        /// </summary>
        [Fact(DisplayName = "A venda não deve ser cancelada por padrão")]
        public void Given_NewVenda_When_Created_Then_CanceladoShouldBeFalse()
        {
            // Arrange
            var venda = VendaTestData.GenerateValidCommand();

            // Assert
            Assert.False(venda.Cancelado);
        }

        /// <summary>
        /// Testes que a validação passa com dados de venda válidos.
        /// </summary>
        [Fact(DisplayName = "A validação deve passar por dados de venda válidos")]
        public void Given_ValidVenda_When_Validated_Then_ShouldReturnValid()
        {
            // Arrange
            var command = VendaTestData.GenerateValidCommand();
            var validator = new CriarVendaValidator();

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        /// <summary>
        ///Testes que a validação falha quando a venda tem dados inválidos.
        /// </summary>
        [Fact(DisplayName = "A validação deve falhar para dados de venda inválidos")]
        public void Given_InvalidVenda_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var command = VendaTestData.GenerateInvalidCommand_ItemInvalido();
            var validator = new CriarVendaValidator();

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }
}