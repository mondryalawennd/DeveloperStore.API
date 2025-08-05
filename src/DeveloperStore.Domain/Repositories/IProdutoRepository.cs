
using DeveloperStore.Domain.Entities;

namespace DeveloperStore.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
