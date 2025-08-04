using FluentValidation;

namespace DeveloperStore.WebAPI.Features.DeletarVenda
{
    public class DeletarVendaRequestValidator : AbstractValidator<DeletarVendaRequest>
    {
        public DeletarVendaRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id da venda deve ser maior que zero.");
        }
    }
}
