using BancoClass.Entities;
using System.ComponentModel.DataAnnotations;

namespace Questor.Dto
{
    #region Get
    public class GetBoletoDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid IdBanco { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "O campo {0} não permite mais que {1} caracteres")]
        public string NomePagador { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string CpfCnpjPagador { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O campo {0} não permite mais que {1} caracteres")]
        public string NomeBeneficiario { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string CpfCnpjBeneficiario { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        [MaxLength(500, ErrorMessage = "O campo {0} não permite mais que {1} caracteres")]
        public string Observacao { get; set; }

        public bool IsAtrasado { get; set; }

        public Banco? Banco { get; set; }

    }
    #endregion

    #region Create
    public class CreateBoletoDto
    {

        [Required]
        public Guid IdBanco { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "O campo {0} não permite mais que {1} caracteres")]
        public string NomePagador { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string CpfCnpjPagador { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O campo {0} não permite mais que {1} caracteres")]
        public string NomeBeneficiario { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string CpfCnpjBeneficiario { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        [MaxLength(500, ErrorMessage = "O campo {0} não permite mais que {1} caracteres")]
        public string Observacao { get; set; }
    }
    #endregion
}
