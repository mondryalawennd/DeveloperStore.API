using DeveloperStore.Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.AlterarVenda
{
    public class ItemVendaDTOValidator : AbstractValidator<ItemVendaDTO>
    {
        public ItemVendaDTOValidator()
        {
            RuleFor(x => x.ProdutoId).GreaterThan(0).WithMessage("ProdutoId inválido.");
            RuleFor(x => x.Quantidade).GreaterThan(0).WithMessage("Quantidade deve ser maior que zero.");
            RuleFor(x => x.PrecoUnitario).GreaterThanOrEqualTo(0).WithMessage("Preço unitário não pode ser negativo.");
            RuleFor(x => x.Desconto).GreaterThanOrEqualTo(0).WithMessage("Desconto não pode ser negativo.");
        }
    }
}
