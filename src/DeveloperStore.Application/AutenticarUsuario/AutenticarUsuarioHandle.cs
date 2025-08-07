using DeveloperStore.Common.Security;
using DeveloperStore.Domain.Repositories;
using DeveloperStore.Domain.Specifications;
using MediatR;

namespace DeveloperStore.Application.AutenticarUsuario
{
    public class AutenticarUsuarioHandle: IRequestHandler<AutenticarUsuarioCommon, AutenticarUsuarioResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AutenticarUsuarioHandle(IUsuarioRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _usuarioRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<AutenticarUsuarioResult> Handle(AutenticarUsuarioCommon request, CancellationToken cancellationToken)
        {
            var _usuario = await _usuarioRepository.GetByEmailAsync(request.Email, cancellationToken);

            if (_usuario == null || !_passwordHasher.VerifyPassword(request.Password, _usuario.Password))
            {
                throw new UnauthorizedAccessException("Credenciais inválidas");
            }

            var usuarioAtivoSpec = new AutenticarUsuarioSpecification();
            if (!usuarioAtivoSpec.IsSatisfiedBy(_usuario))
            {
                throw new UnauthorizedAccessException("O usuário não está ativo");
            }

            var token = _jwtTokenGenerator.GerarToken(_usuario);

            return new AutenticarUsuarioResult
            {
                Token = token,
                Email = _usuario.Email,
                Nome = _usuario.Nome,
                Papel = _usuario.Papel.ToString()
            };
        }
    }
}