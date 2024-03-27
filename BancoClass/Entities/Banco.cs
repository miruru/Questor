using BaseDomain.Models;
using System.ComponentModel.DataAnnotations;

namespace BancoClass.Entities
{
    public class Banco : BaseEntity
    {
        [Required]
        public string NomeBanco { get; set; }

        [Required]
        public string CodigoBanco { get; set; }

        [Required]
        public float PercentualJuros { get; set; }

    }
}
