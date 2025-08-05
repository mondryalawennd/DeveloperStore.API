using FluentValidation;

namespace DeveloperStore.WebAPI.Features.Venda.AlterarVenda
{
    public class AlterarVendaResponseValidator : AbstractValidator<AlterarVendaResponse>
    {
        public AlterarVendaResponseValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.NumeroVenda).NotEmpty();
            RuleFor(x => x.Mensagem).NotEmpty();
        }
    }
}
