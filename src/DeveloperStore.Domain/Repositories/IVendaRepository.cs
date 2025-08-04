using DeveloperStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Domain.Repositories
{
    public interface IVendaRepository
    {
        Task<Venda> GetByIdAsync(int id);
        Task<List<Venda>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(Venda venda);
        Task UpdateAsync(Venda venda);
        Task DeleteAsync(int id);
    }
}
