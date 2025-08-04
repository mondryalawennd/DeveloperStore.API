using FluentValidation;

namespace DeveloperStore.WebAPI.Features.AlterarVenda
{
    public class AlterarVendaRequestValidator : AbstractValidator<AlterarVendaRequest>
    {
        public AlterarVendaRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id da venda é obrigatório.");

            RuleForEach(x => x.Itens).SetValidator(new ItemRequestValidator());
        }

        public class ItemRequestValidator : AbstractValidator<AlterarVendaRequest.ItemRequest>
        {
            public ItemRequestValidator()
            {
                RuleFor(x => x.ProdutoId)
                    .GreaterThan(0).WithMessage("ProdutoId é obrigatório.");

                RuleFor(x => x.Quantidade)
                    .GreaterThan(0).WithMessage("Quantidade deve ser maior que 0.");

                RuleFor(x => x.PrecoUnitario)
                    .GreaterThan(0).WithMessage("Preço unitário deve ser maior que 0.");
            }
        }
    }
}