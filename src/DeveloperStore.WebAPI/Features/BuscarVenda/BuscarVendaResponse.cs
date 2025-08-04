namespace DeveloperStore.WebAPI.Features.BuscarVenda
{
    public class BuscarVendaResponse
    {
        public int Id { get; set; }
        public string NumeroVenda { get; set; } = string.Empty;
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public int FilialId { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Cancelado { get; set; } = false;
        public List<ItemVendaResponse> Itens { get; set; } = new List<ItemVendaResponse>();
    }

    public class ItemVendaResponse
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Cancelado { get; set; } = false;
    }
}
