using FluentValidation;

namespace Boleto.Entities
{
    public class BoletoValidator : AbstractValidator<Boleto>
    {
        public BoletoValidator()
        {
            RuleFor(f => f.NomePagador)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .Length(2, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.CpfCnpjPagador)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .Length(11, 14).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.NomeBeneficiario)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .Length(2, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.CpfCnpjBeneficiario)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .Length(11, 14).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Valor)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser positivo");

            RuleFor(f => f.DataVencimenoto)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => f.Observacao)
                    .Length(0, 500).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }

    }
}
