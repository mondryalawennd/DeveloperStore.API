using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.BuscarVenda
{
    public class BuscarVendaResult
    {
        public int Id { get; set; }
        public string NumeroVenda { get; set; }=string.Empty;
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public int FilialId { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Cancelado { get; set; } = false;

        public List<ItemVendaResult> Itens { get; set; } = new();
    }

    public class ItemVendaResult
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