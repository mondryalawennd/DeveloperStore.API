using DeveloperStore.Domain.Entities;
using DeveloperStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.ORM.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly DefaultContext _context;

        public UsuarioRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateAsync(Usuario usuario, CancellationToken cancellationToken = default)
        {
            await _context.Usuario.AddAsync(usuario, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return usuario;
        }

        public async Task<Usuario?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Usuario.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<Usuario?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Usuario
                .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await GetByIdAsync(id, cancellationToken);
            if (user == null)
                return false;

            _context.Usuario.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
