using System.ComponentModel.DataAnnotations;
using static Teste_FCS.Dto.LivroDTO;

namespace Teste_FCS.Models
{
    public class LivroModel : ModelBase
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public string Editora { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public string Resumo { get; set; }

        public LivroModel() { }

        public LivroModel(LivroCreateDTO dto) {
            Nome = dto.Nome;
            Autor = dto.Autor;
            Editora = dto.Editora;
            Ano = dto.Ano;
            Resumo = dto.Resumo;
        }
    }
}
