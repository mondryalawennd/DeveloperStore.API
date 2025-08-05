namespace DeveloperStore.WebAPI.Features.Venda.CriarVenda
{
    public class CriarVendaResponse
    {
        public int Id { get; set; }
        public string NumeroVenda { get; set; } = string.Empty;
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public List<ItemVendaResponse> Itens { get; set; } = new List<ItemVendaResponse>();
    }

    public class ItemVendaResponse
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotalComDesconto { get; set; }
    }
}
