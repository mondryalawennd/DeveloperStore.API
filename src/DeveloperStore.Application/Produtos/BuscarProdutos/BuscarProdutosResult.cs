

namespace DeveloperStore.Application.Produtos.BuscarProdutos
{
    public class BuscarProdutosResult
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; private set; } = decimal.Zero; 
    }
}
