
namespace DeveloperStore.WebAPI.Features.CriarVenda
{
    public class CriarVendaRequest
    {
        public string NumeroVenda { get; set; } = string.Empty;
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public int FilialId { get; set; }
        public bool Cancelado { get; set; } = false;
        public decimal ValorTotal { get; set; }
        public List<ItemVendaRequest> Itens { get; set; } = new List<ItemVendaRequest>();
    }

    public class ItemVendaRequest
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public bool Cancelado { get; set; } = false;
    }
}