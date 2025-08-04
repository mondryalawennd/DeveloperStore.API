using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.BuscarVendas
{
    public class BuscarVendasResult
    {
        public int Id { get; set; }
        public string NumeroVenda { get; set; }=string.Empty;
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public int FilialId { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Cancelado { get; set; } = false;

        public List<ItensVendaResult> Itens { get; set; } = new List<ItensVendaResult>();
    }

    public class ItensVendaResult
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Cancelado { get; set; } = false;
    }
}