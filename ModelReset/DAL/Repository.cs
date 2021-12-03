using System;
using System.Linq;
using System.Threading.Tasks;
using Catel;
using ModelReset.Contracts;

namespace ModelReset.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly ApplicationContext ApplicationContext;

        public Repository(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return ApplicationContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            Argument.IsNotNull(() => entity);

            try
            {
                await ApplicationContext.AddAsync(entity);

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public TEntity Remove(TEntity entity)
        {
            Argument.IsNotNull(() => entity);

            try
            {
                ApplicationContext.Remove(entity);

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public TEntity Update(TEntity entity)
        {
            Argument.IsNotNull(() => entity);

            try
            {
                ApplicationContext.Update(entity);

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }
}
