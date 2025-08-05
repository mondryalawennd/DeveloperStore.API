using DeveloperStore.Domain.Entities;
using DeveloperStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.ORM.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DefaultContext _context;

        public ClienteRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Cliente
                                 .AsNoTracking()
                                 .ToListAsync(cancellationToken);
        }
    }
}