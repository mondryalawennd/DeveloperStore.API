using FluentValidation;

namespace DeveloperStore.Application.AutenticarUsuario
{
    public class AutenticarUsuarioValidator: AbstractValidator<AutenticarUsuarioCommon>
    {
        public AutenticarUsuarioValidator() {
            RuleFor(x => x.Email)
                   .NotEmpty()
                   .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);

        }
    }
}
