using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.CancelarVenda
{
    public class CancelarVendaResponse
    {
        public int Id { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;

        public static CancelarVendaResponse Success(string mensagem) =>
            new CancelarVendaResponse { Sucesso = true, Mensagem = mensagem };

        public static CancelarVendaResponse Failure(string mensagem) =>
            new CancelarVendaResponse { Sucesso = false, Mensagem = mensagem };

    }
}
