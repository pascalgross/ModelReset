using System;
using System.Threading;
using System.Threading.Tasks;

namespace ModelReset.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task StartTransaction();
        Task CommitTransaction();
        Task SaveChanges();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new();
    }
}