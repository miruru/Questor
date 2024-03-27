using BaseDomain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletoClass.Entities
{
    public class Boleto : BaseEntity
    {

        [ForeignKey("Banco")]
        public int IdBanco { get; set; }

        [Required]
        public string NomePagador { get; set; }

        [Required]
        public string CpfCnpjPagador { get; set; }

        [Required]
        public string NomeBeneficiario { get; set; }

        [Required]
        public string CpfCnpjBeneficiario { get; set; }

        [Required]
        public Double Valor { get; set; }

        [Required]
        public DateTime DataVencimenoto { get; set; }

        public string? Observacao { get; set; }

        // public Banco Banco { get; set; }

        public bool IsAtrasado
        {
            get { return DateTime.Compare(this.DataVencimenoto, DateTime.Now) < 0; }
            set { }
        }
    }
}
