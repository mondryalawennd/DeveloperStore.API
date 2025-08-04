using DeveloperStore.Application.Vendas.AlterarVenda;
using MediatR;

namespace DeveloperStore.WebAPI.Features.AlterarVenda
{
    public class AlterarVendaRequest : IRequest<AlterarVendaResult>
    {
        public int Id { get; set; }
        public List<ItemRequest> Itens { get; set; }

        public class ItemRequest
        {
            public int ProdutoId { get; set; }
            public int Quantidade { get; set; }
            public decimal PrecoUnitario { get; set; }
        }
    }
}
