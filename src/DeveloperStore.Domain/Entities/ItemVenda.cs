namespace DeveloperStore.Domain.Entities
{
    public class ItemVenda
    {
        public int Id { get; private set; }
        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal Desconto { get; private set; }
        public bool Cancelado { get; private set; } = false;
        public decimal ValorTotal { get; private set; }
        public int VendaId { get; private set; }
        public Venda Venda { get; private set; }

        // Construtor só com propriedades mapeadas
        public ItemVenda(int produtoId, int quantidade, decimal precoUnitario)
        {
            ValidarQuantidade(quantidade);
            ValidarPreco(precoUnitario);

            ProdutoId = produtoId;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Cancelado = false;

            Desconto = 0m;
            ValorTotal = 0m;
        }

        protected ItemVenda() { }

        // Método para validar limite e atualizar desconto e total
        public void AtualizarQuantidadeComRegra(int novaQuantidade, int quantidadeTotalProdutoNaVenda)
        {
            ValidarLimiteProduto(novaQuantidade, quantidadeTotalProdutoNaVenda);

            Quantidade = novaQuantidade;

            Desconto = CalcularDesconto(quantidadeTotalProdutoNaVenda + novaQuantidade);
            ValorTotal = CalcularValorTotal();
        }

        public void AtualizarQuantidade(int novaQuantidade)
        {
            Quantidade = novaQuantidade;
        }

        public void AtualizarPreco(decimal novoPreco)
        {
            PrecoUnitario = novoPreco;
        }

        private void ValidarQuantidade(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.", nameof(quantidade));
        }

        private void ValidarPreco(decimal precoUnitario)
        {
            if (precoUnitario < 0)
                throw new ArgumentException("Preço unitário não pode ser negativo.", nameof(precoUnitario));
        }

        private void ValidarLimiteProduto(int novaQuantidade, int quantidadeTotalProduto)
        {
            if (quantidadeTotalProduto + novaQuantidade > 20)
                throw new InvalidOperationException("Não é permitido vender mais de 20 itens idênticos.");
        }

        private decimal CalcularDesconto(int quantidadeTotal)
        {
            if (quantidadeTotal >= 10 && quantidadeTotal <= 20)
                return PrecoUnitario * Quantidade * 0.20m;

            if (quantidadeTotal >= 4)
                return PrecoUnitario * Quantidade * 0.10m;

            return 0m;
        }

        private decimal CalcularValorTotal()
        {
            var totalSemDesconto = Quantidade * PrecoUnitario;
            return totalSemDesconto - Desconto;
        }

        public void Cancelar()
        {
            Cancelado = true;
        }
    }
}
