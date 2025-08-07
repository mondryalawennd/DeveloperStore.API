
using Bogus;
using DeveloperStore.Application.DTO;
using DeveloperStore.Application.Vendas.CriarVenda;

namespace DeveloperStore.Tests.DeveloperStore.Unit.Application.TestData
{
    public class CriarVendaHandlerTestData
    {

        /// <summary>
        /// Configura o Faker para gerar comandos válidos de criação de venda.
        /// Os dados gerados conterão:
        /// - Número da venda (número aleatório)
        /// - Data da venda (UTC)
        /// - ClienteId (positivo)
        /// - FilialId (positivo)
        /// - Itens com produtoId, quantidade e preço unitário válidos
        /// </summary>
        private static readonly Faker<ItemVendaDTO> itemVendaFaker = new Faker<ItemVendaDTO>()
         .RuleFor(i => i.ProdutoId, f => f.Random.Int(1, 100))
         .RuleFor(i => i.Quantidade, f => f.Random.Int(1, 10))
         .RuleFor(i => i.PrecoUnitario, f => f.Finance.Amount(10, 500));

        private static readonly Faker<CriarVendaCommand> criarVendaFaker = new Faker<CriarVendaCommand>()
            .RuleFor(c => c.NumeroVenda, f => f.Random.AlphaNumeric(8))
            .RuleFor(c => c.DataVenda, f => f.Date.Recent())
            .RuleFor(c => c.ClienteId, f => f.Random.Int(1, 50))
            .RuleFor(c => c.FilialId, f => f.Random.Int(1, 10))
            .RuleFor(c => c.ValorTotal, f => f.Finance.Amount(100, 1000))
            .RuleFor(c => c.Cancelado, f => false)
            .RuleFor(c => c.Itens, f => itemVendaFaker.Generate(f.Random.Int(1, 5)));

        public static CriarVendaCommand GenerateValidCommand()
        {
            return criarVendaFaker.Generate();
        }
    }
}
