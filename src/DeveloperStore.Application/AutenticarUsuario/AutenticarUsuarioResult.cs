using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.AutenticarUsuario
{
    public class AutenticarUsuarioResult
    {
        public string Token { get; set; } = string.Empty;
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Papel { get; set; } = string.Empty;
    }
}
