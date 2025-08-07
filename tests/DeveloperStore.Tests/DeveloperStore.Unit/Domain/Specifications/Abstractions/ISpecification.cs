using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Tests.DeveloperStore.Unit.Domain.Specifications.Abstractions
{
    /// <summary>
    /// Interface para especificações do domínio.
    /// Define um critério que uma entidade deve satisfazer.
    /// </summary>
    /// <typeparam name="T">Tipo da entidade.</typeparam>
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
