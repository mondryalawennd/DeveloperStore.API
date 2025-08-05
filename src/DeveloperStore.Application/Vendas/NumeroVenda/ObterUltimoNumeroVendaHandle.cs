using DeveloperStore.Application.Queries;
using DeveloperStore.Domain.Entities;
using DeveloperStore.ORM;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.NumeroVenda
{
    public class ObterUltimoNumeroVendaHandle : IRequestHandler<ObterUltimoNumeroVendaQuery, ObterUltimoNumeroVendaResult>
    {
        private readonly DefaultContext _context;

        public ObterUltimoNumeroVendaHandle(DefaultContext context)
        {
            _context = context;
        }

        public async Task<ObterUltimoNumeroVendaResult> Handle(ObterUltimoNumeroVendaQuery request, CancellationToken cancellationToken)
        {
            var ultimoNumero = await _context.Vendas
                 .OrderByDescending(x => Convert.ToInt32(x.NumeroVenda))
                 .Select(v => v.NumeroVenda)
                 .FirstOrDefaultAsync(cancellationToken);


            if (!string.IsNullOrEmpty(ultimoNumero) && int.TryParse(ultimoNumero, out int numero))
            {
                return new ObterUltimoNumeroVendaResult
                {
                    NumeroVenda = (numero + 1).ToString("D2")
                };
            }

            return new ObterUltimoNumeroVendaResult
            {
                NumeroVenda = "001"
            };
        }
        
    }

}