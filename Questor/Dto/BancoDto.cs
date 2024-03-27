using System.ComponentModel.DataAnnotations;

namespace Questor.Dto
{
    #region Get
    public class GetBancoDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Codigo { get; set; }

        [MaxLength(3, ErrorMessage = "O campo {0} não permite mais que {1} caracteres")]
        public int PercentualJuros { get; set; }
    }
    #endregion

    #region Create
    public class CreateBancoDto
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Codigo { get; set; }

        [Range(0, 999, ErrorMessage = "O campo {0} não permite mais que {1} caracteres")]
        public int PercentualJuros { get; set; }
    }
    #endregion
}
