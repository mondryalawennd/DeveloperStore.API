
using FluentValidation;

namespace DeveloperStore.WebAPI.Features.Venda.CriarVenda
{
    public class CriarVendaRequestValidator : AbstractValidator<CriarVendaRequest>
    {
        public CriarVendaRequestValidator()
        {
            RuleFor(x => x.NumeroVenda)
                .NotEmpty().WithMessage("Número da venda é obrigatório.");

            RuleFor(x => x.DataVenda)
                .NotEmpty().WithMessage("Data da venda é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Data da venda não pode ser no futuro.");

            RuleFor(x => x.ClienteId)
                .NotEmpty().WithMessage("ClienteId é obrigatório.");


            RuleFor(x => x.FilialId)
                .NotEmpty().WithMessage("FilialId é obrigatório.");


            RuleFor(x => x.Itens)
                .NotEmpty().WithMessage("A venda deve conter ao menos um item.");

            RuleForEach(x => x.Itens).SetValidator(new ItemVendaRequestValidator());
        }

    }
}