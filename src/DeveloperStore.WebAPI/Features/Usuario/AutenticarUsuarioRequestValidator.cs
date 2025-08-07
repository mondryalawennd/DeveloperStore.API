using FluentValidation;

namespace DeveloperStore.WebAPI.Features.Usuario
{
    public class AutenticarUsuarioRequestValidator : AbstractValidator<AutenticarUsuarioRequest>
    {
        public AutenticarUsuarioRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório")
                .EmailAddress()
                .WithMessage("Formato de e-mail inválido");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha é obrigatória");
        }
    }
}
