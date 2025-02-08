using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste_FCS.Context;

namespace Teste_FCS.Repositorio.Base
{
    public abstract class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected readonly Db_Context _context;
        protected readonly DbSet<T> _dbSet;

        protected RepositorioBase(Db_Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task AdicionarAsync(T entidade)
        {
            await _dbSet.AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public virtual async Task EditarAsync(T entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task ExcluirAsync(int id)
        {
            var entidade = await BuscarPorIdAsync(id);
            if (entidade != null)
            {
                _dbSet.Remove(entidade);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> BuscarPorIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> BuscarTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
