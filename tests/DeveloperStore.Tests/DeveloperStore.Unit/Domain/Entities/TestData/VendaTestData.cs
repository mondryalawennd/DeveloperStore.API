using Bogus;
using DeveloperStore.Application.DTO;
using DeveloperStore.Application.Vendas.CriarVenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Tests.DeveloperStore.Unit.Domain.Entities.TestData
{
    public static class VendaTestData
    {
        private static readonly Faker<ItemVendaDTO> ItemFaker = new Faker<ItemVendaDTO>()
            .RuleFor(i => i.ProdutoId, f => f.Random.Int(1, 1000))
            .RuleFor(i => i.Quantidade, f => f.Random.Int(1, 10))
            .RuleFor(i => i.PrecoUnitario, f => f.Random.Decimal(1, 1000))
            .RuleFor(i => i.Desconto, f => f.Random.Decimal(0, 50));

        private static readonly Faker<CriarVendaCommand> VendaFaker = new Faker<CriarVendaCommand>()
            .RuleFor(v => v.NumeroVenda, f => f.Random.AlphaNumeric(10))
            .RuleFor(v => v.DataVenda, f => f.Date.Past().ToUniversalTime())
            .RuleFor(v => v.ClienteId, f => f.Random.Int(1, 1000))
            .RuleFor(v => v.FilialId, f => f.Random.Int(1, 100))
            .RuleFor(v => v.ValorTotal, f => f.Random.Decimal(100, 10000))
            .RuleFor(v => v.Cancelado, f => false)
            .RuleFor(v => v.Itens, f => ItemFaker.Generate(f.Random.Int(1, 5)));


        public static CriarVendaCommand GenerateValidCommand()
        {
            return VendaFaker.Generate();
        }


        public static CriarVendaCommand GenerateInvalidCommand_NoNumeroVenda()
        {
            var command = GenerateValidCommand();
            command.NumeroVenda = "";
            return command;
        }

        public static CriarVendaCommand GenerateInvalidCommand_DataFutura()
        {
            var command = GenerateValidCommand();
            command.DataVenda = DateTime.UtcNow.AddDays(1); // data futura
            return command;
        }

        public static CriarVendaCommand GenerateInvalidCommand_ClienteIdZero()
        {
            var command = GenerateValidCommand();
            command.ClienteId = 0;
            return command;
        }

        public static CriarVendaCommand GenerateInvalidCommand_FilialIdZero()
        {
            var command = GenerateValidCommand();
            command.FilialId = 0;
            return command;
        }

        public static CriarVendaCommand GenerateInvalidCommand_ItensVazios()
        {
            var command = GenerateValidCommand();
            command.Itens = new List<ItemVendaDTO>();
            return command;
        }

        public static CriarVendaCommand GenerateInvalidCommand_ItemInvalido()
        {
            var command = GenerateValidCommand();
            var item = command.Itens.First();
            item.Quantidade = 0;
            item.PrecoUnitario = -10;
            item.Desconto = -5;
            return command;
        }
    }
}