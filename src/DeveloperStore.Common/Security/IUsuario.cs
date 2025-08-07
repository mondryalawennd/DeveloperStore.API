using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Common.Security
{
    public interface IUsuario
    {
        public string Id { get; }
        public string Nome { get; }
        public string Papel { get; }
    }
}
