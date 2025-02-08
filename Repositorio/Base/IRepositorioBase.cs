namespace Teste_FCS.Repositorio.Base
{
    public interface IRepositorioBase<T> where T : class
    {
        Task AdicionarAsync(T entidade);
        Task EditarAsync(T entidade);
        Task ExcluirAsync(int id);
        Task<T> BuscarPorIdAsync(int id);
        Task<IEnumerable<T>> BuscarTodosAsync();
    }
}
