using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeveloperStore.Domain.Validator
{
    public class EmailValidator : AbstractValidator<string>
    {
        public EmailValidator()
        {
            RuleFor(email => email)
                .NotEmpty()
                .WithMessage("O e-mail não pode estar vazio")
                .MaximumLength(100)
                .WithMessage("O e-mail não pode ter mais de 100 caracteres.")
                .Must(EmailValido)
                .WithMessage("O e-mail fornecido não é válido.");
        }

        private bool EmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regex.IsMatch(email);
        }
    }
}