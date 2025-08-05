using DeveloperStore.Domain.Entities;
using DeveloperStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.ORM.Repositories
{
    namespace DeveloperStore.Infra.Repositories
    {
        public class VendaRepository : IVendaRepository
        {
            private readonly DefaultContext _context;

            public VendaRepository(DefaultContext context)
            {
                _context = context;
            }

            public async Task<Venda> GetByIdAsync(int id)
            {
                #pragma warning disable CS8603 // Possible null reference return.
                return await _context.Vendas
                    .Include(v => v.Itens)
                    .FirstOrDefaultAsync(v => v.Id == id);
                #pragma warning restore CS8603 // Possible null reference return.
            }

            public async Task<List<Venda>> GetAllAsync(CancellationToken cancellationToken)
            {
                return await _context.Vendas
                    .Include(v => v.Cliente)  
                    .Include(v => v.Filial)
                    .Include(v => v.Itens)
                    .ToListAsync(cancellationToken);
            }

            public async Task AddAsync(Venda venda)
            {
                await _context.Vendas.AddAsync(venda);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateAsync(Venda venda)
            {
                _context.Vendas.Update(venda);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var venda = await GetByIdAsync(id);
                if (venda != null)
                {
                    _context.Vendas.Remove(venda);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}