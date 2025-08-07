using DeveloperStore.Domain.Entities;
using DeveloperStore.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Domain.Specifications
{
    public class AutenticarUsuarioSpecification : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return usuario.Status == UsuarioStatus.Ativo;
        }
    }
}