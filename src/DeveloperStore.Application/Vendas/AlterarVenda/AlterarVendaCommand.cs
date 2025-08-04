using DeveloperStore.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.AlterarVenda
{
    public class AlterarVendaCommand : IRequest<AlterarVendaResult>
    {
        public int Id { get; set; }
        public string NumeroVenda { get; set; } = string.Empty;
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public int FilialId { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Cancelado { get; set; } = false;

        public List<ItemVendaDTO> Itens { get; set; } = new();
    }
}
