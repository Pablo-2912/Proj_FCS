using Teste_FCS.Negocio.Base;
using Teste_FCS.Models;

namespace Teste_FCS.Negocio.Livro
{
    public class LivroService : ServiceBase<LivroModel>, ILivroService
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroService(ILivroRepositorio livroRepositorio) : base(livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public async Task<IEnumerable<LivroModel>> BuscarPorNomeAutorEditoraAsync(string termo)
        {
            return await _livroRepositorio.BuscarPorNomeAutorEditoraAsync(termo);
        }
    }
}
