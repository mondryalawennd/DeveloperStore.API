

using System;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperStore.Domain.Entities
{
    public class Venda
    {
        public int Id { get;  set; }
        public string NumeroVenda { get;  set; }
        public DateTime DataVenda { get;  set; } = DateTime.UtcNow;
        public int ClienteId { get;  set; }
        public Cliente Cliente { get;  set; }
        public int FilialId { get;  set; }
        public Filial Filial { get;  set; }
        public bool Cancelado { get;  set; } = false;

        private readonly List<ItemVenda> _itens = new List<ItemVenda>();
        public IReadOnlyCollection<ItemVenda> Itens => _itens.AsReadOnly();

        public decimal ValorTotal { get; set; }

        public Venda(string numeroVenda, DateTime dataVenda, int clienteId, int filialId, decimal valorTotal)
        {
            NumeroVenda = numeroVenda;
            DataVenda = dataVenda;
            ClienteId = clienteId;
            FilialId = filialId;
            Cancelado = false;
            ValorTotal = valorTotal;
            _itens = new List<ItemVenda>();
        }

        // Adiciona um item com as regras de negócio
        public void AdicionarItem(int produtoId, int quantidade, decimal precoUnitario)
        {
            var itemExistente = _itens.FirstOrDefault(i => i.ProdutoId == produtoId);

            if (itemExistente != null)
            {
                itemExistente.AtualizarQuantidade(quantidade);
                itemExistente.AtualizarPreco(precoUnitario);
            }
            else
            {
                var item = new ItemVenda(produtoId, quantidade, precoUnitario);
                _itens.Add(item);
            }

           // RecalcularTotais();
        }
      

        private void ValidarItens(int quantidadeAtualDoProduto, int quantidade)
        {
           
            //Soma os itens do mesmo ProdutoId que já foram adicionados e não estão cancelados.
            if ((quantidadeAtualDoProduto + quantidade) > 20)
                throw new InvalidOperationException("Não é permitido vender mais de 20 itens idênticos.");
        }
        public void LimparItens()
        {
            _itens.Clear();
           // RecalcularTotais();
        }

        public void AlterarDados(string numeroVenda, DateTime dataVenda, int clienteId, int filialId)
        {
            NumeroVenda = numeroVenda;
            DataVenda = dataVenda;
            ClienteId = clienteId;
            FilialId = filialId;
        }
        private void RecalcularTotais()
        {
            ValorTotal = Itens.Where(i => !i.Cancelado).Sum(i => i.ValorTotal);
        }

        public void Cancelar()
        {
            Cancelado = true;
            foreach (var item in _itens)
            {
                item.Cancelar();
            }
        }
    }
}
