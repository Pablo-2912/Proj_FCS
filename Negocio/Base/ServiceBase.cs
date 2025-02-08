using Teste_FCS.Repositorio.Base;

namespace Teste_FCS.Negocio.Base
{
    public abstract class ServiceBase<T> where T : class
    {
        protected readonly IRepositorioBase<T> _repositorio;

        protected ServiceBase(IRepositorioBase<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public virtual async Task AdicionarAsync(T entidade)
        {
            await _repositorio.AdicionarAsync(entidade);
        }

        public virtual async Task EditarAsync(T entidade)
        {
            await _repositorio.EditarAsync(entidade);
        }

        public virtual async Task ExcluirAsync(int id)
        {
            await _repositorio.ExcluirAsync(id);
        }

        public virtual async Task<T> BuscarPorIdAsync(int id)
        {
            return await _repositorio.BuscarPorIdAsync(id);
        }

        public virtual async Task<IEnumerable<T>> BuscarTodosAsync()
        {
            return await _repositorio.BuscarTodosAsync();
        }
    }
}
