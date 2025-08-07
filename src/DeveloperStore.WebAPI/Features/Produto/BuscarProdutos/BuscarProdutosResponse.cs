namespace DeveloperStore.WebAPI.Features.Produto.BuscarProdutos
{
    public class BuscarProdutosResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; private set; } = decimal.Zero;
    }
    }
