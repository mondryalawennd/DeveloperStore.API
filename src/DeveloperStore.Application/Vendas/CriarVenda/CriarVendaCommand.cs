using DeveloperStore.Application.DTO;
using DeveloperStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.CriarVenda
{
    public class CriarVendaCommand : IRequest<CriarVendaResult>
    {
        public string NumeroVenda { get; set; } = string.Empty;
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public int FilialId { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Cancelado { get; set; } = false;

        public List<ItemVendaDTO> Itens { get; set; } = new();
    }
}