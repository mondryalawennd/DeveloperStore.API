namespace DeveloperStore.WebAPI.Features.Venda.AlterarVenda
{
    public class AlterarVendaResponse
    {
        public int Id { get; set; }
        public string NumeroVenda { get; set; } = string.Empty;
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
    }
}
