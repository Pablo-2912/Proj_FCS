using Teste_FCS.Models;

namespace Teste_FCS.Negocio.Livro
{
    public interface ILivroService
    {
        Task AdicionarAsync(LivroModel livro);
        Task EditarAsync(LivroModel livro);
        Task ExcluirAsync(int id);
        Task<LivroModel> BuscarPorIdAsync(int id);
        Task<IEnumerable<LivroModel>> BuscarTodosAsync();
        Task<IEnumerable<LivroModel>> BuscarPorNomeAutorEditoraAsync(string termo);
    }
}
