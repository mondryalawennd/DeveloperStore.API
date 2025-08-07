using Bogus;
using DeveloperStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DeveloperStore.Tests.DeveloperStore.Unit.Domain.Specifications.TestData
{
    public static class VendaSpecificationTestData
    {
        /// <summary>
        /// Configura o Faker para gerar entidades Venda válidas.
        /// As vendas geradas terão:
        /// - Número de venda
        /// - Dados válidos
        /// - ClienteId e FilialId positivos
        /// - Valor total positivo
        /// - Lista de itens válidos
        /// </summary>
        private static readonly Faker<Venda> vendaFaker = new Faker<Venda>()
            .CustomInstantiator(f => new Venda(
                f.Commerce.Ean8(),                   
                f.Date.Past(),                       
                f.Random.Int(1, 100),                
                f.Random.Int(1, 10)                 
            ))
            .RuleFor(v => v.ValorTotal, f => f.Finance.Amount(50, 1000))
            .RuleFor(v => v.Cancelado, f => false)
            .RuleFor(v => v.Itens, f => new List<ItemVenda>
            {
                new ItemVenda(
                    f.Random.Int(1, 100),              
                    f.Random.Int(1, 10),               
                    f.Finance.Amount(10, 100)         
                    
                )
            });

        /// <summary>
        /// Gera uma Venda com um status de cancelamento específico.
        /// </summary>
        /// <param name="cancelado">Se a venda deve ser cancelada.</param>
        /// <returns>Uma Venda com o status de cancelamento especificado.</returns>
        public static Venda GenerateVenda(bool cancelado)
        {
            var venda = vendaFaker.Generate();
            venda.Cancelado = cancelado;
            return venda;
        }
    }
}
