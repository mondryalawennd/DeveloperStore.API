using DeveloperStore.Domain.Entities;
using DeveloperStore.Tests.DeveloperStore.Unit.Domain.Specifications.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Tests.DeveloperStore.Unit.Domain.Specifications
{
    /// <summary>
    /// Verifica se a venda é válida: valor total > 0, itens válidos.
    /// </summary>
    public class VendaValidaSpecification : ISpecification<Venda>
    {
        public bool IsSatisfiedBy(Venda venda)
        {
            if (venda == null) return false;

            return venda.ValorTotal > 0 &&
                   venda.Itens != null &&
                   venda.Itens.Any() &&
                   venda.Itens.All(i => i.Quantidade > 0 && i.PrecoUnitario > 0);
        }
    }
}