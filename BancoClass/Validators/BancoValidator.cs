using Banco.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Validators
{
    public class BancoValidator : AbstractValidator<BancoClass>
    {
        public BancoValidator()
        {
            RuleFor(f => f.NomeBanco)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                   .Length(2, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.CodigoBanco)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                   .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.PercentualJuros)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                   .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser positivo");
        }
    }
}
