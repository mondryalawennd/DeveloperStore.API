using DeveloperStore.Application.DTO;
using FluentValidation;

namespace DeveloperStore.Application.Vendas.CriarVenda
{
    public class ItemVendaValidator : AbstractValidator<ItemVendaDTO>
    {
        public ItemVendaValidator()
        {
            RuleFor(i => i.Quantidade)
                .LessThanOrEqualTo(20).WithMessage("Não é permitido vender mais de 20 unidades de um mesmo produto.");

            RuleFor(i => i)
                .Custom((item, context) =>
                {
                    // Sem desconto se quantidade < 4
                    if (item.Quantidade < 4 && item.Desconto > 0)
                    {
                        context.AddFailure("Desconto não é permitido para quantidades abaixo de 4.");
                    }

                    // Desconto de 10% para 4 a 9 unidades
                    if (item.Quantidade >= 4 && item.Quantidade < 10 && item.Desconto != Math.Round(item.PrecoUnitario * 0.10m, 2))
                    {
                        context.AddFailure($"O desconto para {item.Quantidade} unidades deve ser de 10%.");
                    }

                    // Desconto de 20% para 10 a 20 unidades
                    if (item.Quantidade >= 10 && item.Quantidade <= 20 && item.Desconto != Math.Round(item.PrecoUnitario * 0.20m, 2))
                    {
                        context.AddFailure($"O desconto para {item.Quantidade} unidades deve ser de 20%.");
                    }
                });
        }
    }
}
