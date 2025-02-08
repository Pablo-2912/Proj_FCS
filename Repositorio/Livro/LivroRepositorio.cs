using Microsoft.EntityFrameworkCore;
using Teste_FCS.Context;
using Teste_FCS.Models;
using Teste_FCS.Repositorio.Base;

namespace Teste_FCS.Negocio.Livro
{
    public class LivroRepositorio : RepositorioBase<LivroModel>, ILivroRepositorio
    {
        public LivroRepositorio(Db_Context context) : base(context) { }

        public async Task<IEnumerable<LivroModel>> BuscarPorNomeAutorEditoraAsync(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
                return new List<LivroModel>(); // Retorna lista vazia se o termo for inválido

            return await _dbSet
                .AsNoTracking() // Melhora o desempenho para consultas somente leitura
                .Where(l =>
                    l.Nome.Contains(termo) ||
                    l.Autor.Contains(termo) ||
                    l.Editora.Contains(termo))
                .ToListAsync();
        }
    }
}
