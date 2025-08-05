using DeveloperStore.Domain.Entities;

namespace DeveloperStore.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllAsync(CancellationToken cancellationToken);
    }
}
