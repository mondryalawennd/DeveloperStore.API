using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.CriarVenda
{
    public class CriarVendaValidator : AbstractValidator<CriarVendaCommand>
    {
        public CriarVendaValidator()
        {
            RuleFor(x => x.NumeroVenda)
                .NotEmpty().WithMessage("O número da venda é obrigatório.");

            RuleFor(x => x.DataVenda)
                .NotEmpty().WithMessage("A data da venda é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data da venda não pode estar no futuro.");

            RuleFor(x => x.ClienteId)
                .GreaterThan(0).WithMessage("Cliente inválido.");

            RuleFor(x => x.FilialId)
                .GreaterThan(0).WithMessage("Filial inválida.");

            RuleFor(x => x.Itens)
                .NotEmpty().WithMessage("A venda deve conter pelo menos um item.")
                .Must(x => x.All(i => i.Quantidade > 0)).WithMessage("A quantidade de cada item deve ser maior que zero.")
                .Must(x => x.All(i => i.PrecoUnitario > 0)).WithMessage("O preço unitário de cada item deve ser maior que zero.")
                .Must(x => x.All(i => i.Desconto >= 0)).WithMessage("O desconto não pode ser negativo.");

            RuleForEach(x => x.Itens).SetValidator(new ItemVendaValidator());
        }

    }
}