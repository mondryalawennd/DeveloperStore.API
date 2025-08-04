using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Domain.Entities
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public decimal Preco { get; private set; }
    }
}
