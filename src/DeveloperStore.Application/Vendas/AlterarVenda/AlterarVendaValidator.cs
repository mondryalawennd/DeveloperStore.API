using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.AlterarVenda
{
    public class AlterarVendaValidator : AbstractValidator<AlterarVendaCommand>
    {
        public AlterarVendaValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id da venda inválido.");
            RuleFor(x => x.NumeroVenda).NotEmpty().WithMessage("Número da venda obrigatório.");
            RuleFor(x => x.DataVenda).NotEmpty().WithMessage("Data da venda obrigatória.");
            RuleFor(x => x.ClienteId).GreaterThan(0).WithMessage("ClienteId inválido.");
            RuleFor(x => x.FilialId).GreaterThan(0).WithMessage("FilialId inválido.");
            RuleForEach(x => x.Itens).SetValidator(new ItemVendaDTOValidator());
        }
    }
}