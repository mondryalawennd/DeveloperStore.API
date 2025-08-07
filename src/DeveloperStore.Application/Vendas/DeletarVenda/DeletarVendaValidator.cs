using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.DeletarVenda
{
    public  class DeletarVendaValidator : AbstractValidator<DeletarVendaCommand>
    {
        public DeletarVendaValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Venda ID é obrigatório");
        }
    }
}
