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
    /// Verifica se uma venda foi cancelada.
    /// </summary>
    public class VendaCanceladaSpecification : ISpecification<Venda>
    {
        public bool IsSatisfiedBy(Venda venda)
        {
            return venda.Cancelado;
        }
    }
}