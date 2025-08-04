using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.AlterarVenda
{
    public class AlterarVendaResult
    {
        public int Id { get; set; }
        public string NumeroVenda { get; set; } = string.Empty;
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
    }
}
