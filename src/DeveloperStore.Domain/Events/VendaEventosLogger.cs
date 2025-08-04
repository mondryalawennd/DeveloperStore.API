using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Domain.Events
{
    public class VendaEventosLogger
    {
        private readonly ILogger<VendaEventosLogger> _logger;

        public static void VendaCriada(int vendaId)
        {
            Console.WriteLine($"[Evento] VendaCriada - VendaID: {vendaId}");
        }

        public static void VendaModificada(int vendaId)
        {
            Console.WriteLine($"[Evento] VendaModificada - VendaID: {vendaId}");
        }

        public static void VendaCancelada(int vendaId)
        {
            Console.WriteLine($"[Evento] VendaCancelada - VendaID: {vendaId}");
        }

        public static void ItemCancelado(int itemId)
        {
            Console.WriteLine($"[Evento] ItemCancelado - ItemID: {itemId}");
        }
    }
}