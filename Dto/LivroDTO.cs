using System.ComponentModel.DataAnnotations;

namespace Teste_FCS.Dto
{
    public class LivroDTO
    {

        public class LivroCreateDTO
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
        }

        public class LivroUpdateDTO
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public string Autor { get; set; }

            public string Editora { get; set; }

            public int Ano { get; set; }

            public string Resumo { get; set; }
        }
    }
}
