using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Vendas.BuscarVenda
{
    public class BuscarVendaValidator : AbstractValidator<BuscarVendaCommand>
    {
        public BuscarVendaValidator()
        {
            RuleFor(x => x.VendaId)
                .GreaterThan(0)
                .WithMessage("Id da venda deve ser maior que zero.");
        }
    }
}
