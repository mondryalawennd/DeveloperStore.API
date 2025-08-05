using FluentValidation;

namespace DeveloperStore.WebAPI.Features.Venda.CriarVenda
{
    public class ItemVendaRequestValidator : AbstractValidator<ItemVendaRequest>
    {
        public ItemVendaRequestValidator()
        {
            RuleFor(i => i.ProdutoId)
                .NotEmpty().WithMessage("O ID do produto é obrigatório.");

            RuleFor(i => i.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.")
                .LessThanOrEqualTo(20).WithMessage("Não é permitido vender mais de 20 itens idênticos.");

            RuleFor(i => i.PrecoUnitario)
                .GreaterThan(0).WithMessage("O preço unitário deve ser maior que zero.");

            RuleFor(i => i.Desconto)
                .Must((item, desconto) => ValidarDesconto(item.Quantidade, desconto))
                .WithMessage("Desconto inválido para a quantidade informada.");
        }

        private bool ValidarDesconto(int quantidade, decimal desconto)
        {
            if (quantidade < 4)
                return desconto == 0;

            if (quantidade >= 4 && quantidade < 10)
                return desconto == 0.10m;

            if (quantidade >= 10 && quantidade <= 20)
                return desconto == 0.20m;

            return false;
        }
    }
}
