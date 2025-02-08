using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Teste_FCS.Models
{
    public class ModelBase
    {
        [Key] // Define que é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Define que é uma identidade
        public int id { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Required]
        public DateTime DataAlteraco { get; set; } = DateTime.Now;

    }
}
