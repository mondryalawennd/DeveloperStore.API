using FluentValidation;

namespace DeveloperStore.WebAPI.Features.BuscarVenda
{
    public class BuscarVendaResponseValidator : AbstractValidator<BuscarVendaResponse>
    {
        public BuscarVendaResponseValidator()
        {
            RuleForEach(x => x.Itens).SetValidator(new ItemVendaResponseValidator());
        }

        private class ItemVendaResponseValidator : AbstractValidator<ItemVendaResponse>
        {
            public ItemVendaResponseValidator()
            {
                RuleFor(x => x.ProdutoId).GreaterThan(0);
                RuleFor(x => x.Quantidade).GreaterThan(0);
                RuleFor(x => x.PrecoUnitario).GreaterThanOrEqualTo(0);
                RuleFor(x => x.Desconto).GreaterThanOrEqualTo(0);
                RuleFor(x => x.ValorTotal).GreaterThanOrEqualTo(0);
            }
        }
    }
}