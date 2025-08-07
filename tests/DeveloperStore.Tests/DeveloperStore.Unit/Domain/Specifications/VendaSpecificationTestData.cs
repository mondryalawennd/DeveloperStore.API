
using DeveloperStore.Tests.DeveloperStore.Unit.Domain.Specifications.TestData;
using FluentAssertions;
using Xunit;

namespace DeveloperStore.Tests.DeveloperStore.Unit.Domain.Specifications
{
    public class VendaCanceladaSpecificationTests
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void IsSatisfiedBy_ShouldValidateCancelamentoVenda(bool cancelado, bool expected)
        {
            // Arrange
            var venda = VendaSpecificationTestData.GenerateVenda(cancelado);
            var specification = new VendaCanceladaSpecification();

            // Act
            var result = specification.IsSatisfiedBy(venda);

            // Assert
            result.Should().Be(expected);
        }
    }
}
