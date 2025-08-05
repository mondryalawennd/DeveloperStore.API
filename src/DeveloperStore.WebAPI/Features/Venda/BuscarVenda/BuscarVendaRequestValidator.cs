using FluentValidation;

namespace DeveloperStore.WebAPI.Features.Venda.BuscarVenda
{
    public class BuscarVendaRequestValidator : AbstractValidator<BuscarVendaRequest>
    {
        public BuscarVendaRequestValidator()
        {
            RuleFor(x => x.VendaId)
                .GreaterThan(0)
                .WithMessage("VendaId deve ser maior que zero.");
        }
    }
}