using DeveloperStore.Domain.Entities;

namespace DeveloperStore.Domain.Repositories
{
    public interface IFilialRepository
    {
        Task<List<Filial>> GetAllAsync(CancellationToken cancellationToken);
    }
}
