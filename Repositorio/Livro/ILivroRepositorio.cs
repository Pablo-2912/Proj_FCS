using Teste_FCS.Models;
using Teste_FCS.Repositorio.Base;

namespace Teste_FCS.Negocio.Livro
{
    public interface ILivroRepositorio : IRepositorioBase<LivroModel>
    {
        Task AdicionarAsync(LivroModel entidade);
        Task EditarAsync(LivroModel entidade);
        Task ExcluirAsync(int id);
        Task<LivroModel> BuscarPorIdAsync(int id);
        Task<IEnumerable<LivroModel>> BuscarTodosAsync();

        // Método específico para Livro
        Task<IEnumerable<LivroModel>> BuscarPorNomeAutorEditoraAsync(string termo);
    }
}
