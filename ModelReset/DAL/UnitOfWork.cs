using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using ModelReset.Contracts;

namespace ModelReset.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task StartTransaction()
        {
            _transaction = await _applicationContext.Database.BeginTransactionAsync();
        }

        public async Task SaveChanges()
        {
            await _applicationContext.SaveChangesAsync();
        }
        
        public async Task CommitTransaction()
        {
            await _transaction.CommitAsync();
            _transaction?.Dispose();
            _transaction = null;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new()
        {
            return new Repository<TEntity>(_applicationContext);
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _transaction = null;
        }
    }
}