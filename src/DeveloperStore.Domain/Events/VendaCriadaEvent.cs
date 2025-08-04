using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Domain.Events
{
    public class VendaCriadaEvent : INotification
    {
        public int VendaId { get; }
        public string NumeroVenda { get; }
        public int ClienteId { get; }
        public decimal ValorTotal { get; }

        public VendaCriadaEvent(int vendaId, string numeroVenda, int clienteId, decimal valorTotal)
        {
            VendaId = vendaId;
            NumeroVenda = numeroVenda;
            ClienteId = clienteId;
            ValorTotal = valorTotal;
        }
    }
}