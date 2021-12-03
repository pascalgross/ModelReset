using System.Linq;
using System.Threading.Tasks;

namespace ModelReset.Contracts
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> Add(TEntity entity);

        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);
    }
}