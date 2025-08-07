using DeveloperStore.Domain.Entities;
using DeveloperStore.Domain.Enum;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Identity;

namespace DeveloperStore.Domain.Validator
{
    public class UsuarioValidator:AbstractValidator<Usuario>
    {
        public UsuarioValidator() 
        {
            RuleFor(usuario => usuario.Email).SetValidator(new EmailValidator());

            RuleFor(usuario => usuario.Nome)
                .NotEmpty()
                .MinimumLength(3).WithMessage("O nome de usuário deve ter pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("O nome de usuário não pode ter mais de 50 caracteres.");

            RuleFor(usuario => usuario.Password).SetValidator(new SenhaValidator());
                      
            RuleFor(usuario => usuario.Status)
                .NotEqual(UsuarioStatus.Desconhecido)
                .WithMessage("O status do usuário não pode ser Desconhecido.");

        }
    }
}
