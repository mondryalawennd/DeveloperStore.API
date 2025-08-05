using DeveloperStore.Domain.Entities;
using DeveloperStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.ORM.Repositories
{
    public class FilialRepository: IFilialRepository
    {
        private readonly DefaultContext _context;

        public FilialRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<List<Filial>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Filial
                                 .AsNoTracking()
                                 .ToListAsync(cancellationToken);
        }
    }
}