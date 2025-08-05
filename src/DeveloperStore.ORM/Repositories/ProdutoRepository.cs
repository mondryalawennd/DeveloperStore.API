using DeveloperStore.Domain.Entities;
using DeveloperStore.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.ORM.Repositories
{
    public class ProdutoRepository: IProdutoRepository
    {
        private readonly DefaultContext _context;

        public ProdutoRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Produto
                                 .AsNoTracking()
                                 .ToListAsync(cancellationToken);
        }
    }
}